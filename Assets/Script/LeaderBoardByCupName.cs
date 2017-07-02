using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardByCupName : MonoBehaviour
{
    public Transform ScoreHolder;
    public Transform PlayerNameHolder;
    private Text _curentScore;

    public string CupName;
    private string _curPlayer;
    private string _json;

    private LeaderboardNames _playerlist;

    // Use this for initialization
    void Start()
    {
        DownloadLeaderboard();
        _curentScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DownloadLeaderboard()
    {
        if (!PlayerPrefs.HasKey(CupName))
        {
            _playerlist = new LeaderboardNames { PlayerNames = new List<string>() };
            var a = JsonUtility.ToJson(_playerlist);
            PlayerPrefs.SetString(CupName, a);
        }
        _playerlist = JsonUtility.FromJson<LeaderboardNames>(PlayerPrefs.GetString(CupName));
        for (int i = 0; i < _playerlist.PlayerNames.Count; i++)
        {
            PlayerNameHolder.GetChild(i).GetComponent<Text>().text =
                _playerlist.PlayerNames[i];
            ScoreHolder.GetChild(i).GetComponent<Text>().text = "" +
                PlayerPrefs.GetInt(_playerlist.PlayerNames[i]);
        }

    }

    public string CurentPlayerName
    {
        get
        {
            if (string.IsNullOrEmpty(_curPlayer))
            {
                _curPlayer = "";
            }
            return _curPlayer;
        }
        set { _curPlayer = value; }
    }

    public void NewHightScore()
    {
        _playerlist = JsonUtility.FromJson<LeaderboardNames>(PlayerPrefs.GetString(CupName));
        var playerCount = _playerlist.PlayerNames.Count;
        string newScore = _curentScore.text;
        bool moved = false;
        int playerPos = playerCount;

        for (int i = playerCount; i > 0; i--)
        {
            if (Convert.ToInt32(_curentScore.text) >
                Convert.ToInt32(ScoreHolder.GetChild(i - 1).GetComponent<Text>().text))
            {
                playerPos = i;
                moved = true;
            }
        }
        if (moved == false)
        {
            _playerlist.PlayerNames.Add(CurentPlayerName);
        }
        if (moved)
        {
            _playerlist.PlayerNames.Insert(playerPos-1, CurentPlayerName);
        }
        if (_playerlist.PlayerNames.Count == 11)
        {
            PlayerPrefs.DeleteKey(_playerlist.PlayerNames.Last());
            _playerlist.PlayerNames.RemoveAt(10);
        }
        PlayerPrefs.SetInt(CurentPlayerName, Convert.ToInt32(newScore));
        _json = JsonUtility.ToJson(_playerlist);
        PlayerPrefs.SetString(CupName, _json);
        DownloadLeaderboard();

    }

    public class LeaderboardNames
    {
        [SerializeField]
        public List<string> PlayerNames;

    }
}
