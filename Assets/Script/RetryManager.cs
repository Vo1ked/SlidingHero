using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryManager : MonoBehaviour
{
    private GameObject _player;
    public GameObject OnOffPanel;
    public GameObject CointsHolder;

    private Text _score;

    private Vector3 _playerStartPos;

    private float _playerStartSpeed;

    private PlayerControler _playerSpeed;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStartPos = _player.transform.position;
        _playerSpeed = _player.GetComponent<PlayerControler>();
        _playerStartSpeed = _playerSpeed.Speed;
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetGameEasy()
    {

        ActivateLikesRederer();
        _score.text = "0";
        _player.transform.position = _playerStartPos;
        OnOffPanel.SetActive(false);
        _playerSpeed.Speed = _playerStartSpeed;
    }

    public void ResetGameHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }

    private void ActivateLikesRederer()
    {
        for (int i = 0; i < CointsHolder.transform.childCount; i++)
        {
            CointsHolder.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
