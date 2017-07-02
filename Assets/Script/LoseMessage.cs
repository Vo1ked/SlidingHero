using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMessage : MonoBehaviour
{
    public GameObject LoseMassageObj;
    public GameObject HightScoreParent;

    public bool SetActive;

    public Text ScoreInMessage;
    private Text _score;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
    void Update () {
		ActivedChild();
	}
    public void ActivedChild()
        {
            if (SetActive)
            {
                ScoreInMessage.text = _score.text;
                LoseMassageObj.SetActive(true);
                SetActive = false;
            }
        }

    public void CheckHightScoreInEndless()
    {
        if (SceneManager.GetActiveScene().name == "EndlessSliding")
        {
            ActivedChild();
            if (Convert.ToInt32(GameObject.FindGameObjectWithTag("LastHightScore").GetComponent<Text>().text) <
                Convert.ToInt32(ScoreInMessage.text))
            {
                HightScoreParent.SetActive(true);

            }
        }
    }
    }

