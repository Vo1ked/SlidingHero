using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private PlayerControler _player;
    private float _curSpeed;
    private bool PauseIsActipe;
	// Use this for initialization
	void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!PauseIsActipe)
	        _curSpeed = _player.Speed;
	}
    // add to Pause button click 
    public void Pause()
    {
        PauseIsActipe = !PauseIsActipe;
        if (PauseIsActipe)
            _player.PlayerSpeed = 0;
        if (!PauseIsActipe)
            _player.Speed = _curSpeed;
    }
}
