using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LikeRotation : MonoBehaviour
{
    public float RotateSpeed;

    private Text _score;

    private int _curScore;

    private bool _rendererSwitch;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        _rendererSwitch = GetComponent<Renderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rendererSwitch)
            transform.Rotate(Vector3.back, RotateSpeed*Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            int.TryParse(_score.text, out _curScore);
            _curScore++;
            _score.text = "" + _curScore;
            _rendererSwitch = false;
            GetComponent<Renderer>().enabled = _rendererSwitch;
        }
    }
}
