using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsController : MonoBehaviour {

	public Text bronzeCupList;
	public Text silverCupList;
	public Text goldenCupList;

	void Start () {
		SetScoreForCup ("LeaderboardNames", bronzeCupList);
		SetScoreForCup ("SilverLeaderBoard", silverCupList);
		SetScoreForCup ("GoldCup", goldenCupList);

	}

	private void SetScoreForCup(string cupName, Text cupText)
	{
		if (PlayerPrefs.HasKey(cupName)) {
			var playerlist = JsonUtility.FromJson<LeaderBoardByCupName.LeaderboardNames>(PlayerPrefs.GetString(cupName));
			if (playerlist.PlayerNames.Count > 0)
				cupText.text = "";
			for (int i = 0; i < playerlist.PlayerNames.Count; i++) {
				var name = playerlist.PlayerNames[i]; // Name
				var score = "" + PlayerPrefs.GetInt(name); // Score
				cupText.text += (i + 1) + ".\t" + name + ":\t" + score + "\n";
			}
		}
	}
}
