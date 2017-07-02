using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTouch : MonoBehaviour
{

    private PlayerControler _player;
    private LoseMessage _attaceScript;
	// Use this for initialization
	void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        _attaceScript = GameObject.FindGameObjectWithTag("MessageDie").GetComponent<LoseMessage>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            _player.Speed = 0;
            _attaceScript.SetActive = true;
        }

    }
}
