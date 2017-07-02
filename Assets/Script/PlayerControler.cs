using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public bool MoveToCenterComplite;
    public bool LeftMoving, RightMoving, Moving, PkMove;
    private bool _returnRotation;

    public float TurnSpeed, Speed, RotateSpeed;
    private float _angle, _startAngle;
    public float MaxAngle;


    private CharacterController _charterMove;

    private Vector3 _forwardmove, _startRotation, _returnRotationDirection;

    private Transform _playerRotate;

    // Use this for initialization
    void Start()
    {
        LeftMoving = false;
        RightMoving = false;
        Moving = true;
        _charterMove = GetComponent<CharacterController>();
        _forwardmove = new Vector3(0, -1f, 1);
        _playerRotate = transform.GetChild(0);
        _startRotation = _playerRotate.localEulerAngles;
        _startAngle = Quaternion.Angle(transform.rotation, _playerRotate.rotation);
        _returnRotationDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            _charterMove.Move(_forwardmove * Speed);
            _angle = Quaternion.Angle(transform.rotation, _playerRotate.rotation);
            PkMoveControll();
            if (LeftMoving)
            {
                _charterMove.Move(Vector3.left * TurnSpeed);
                FixCharterRotateByDirection(Vector3.back);
                _returnRotationDirection = Vector3.forward;
            }
            if (RightMoving)
            {
                _charterMove.Move(Vector3.right * TurnSpeed);
                FixCharterRotateByDirection(Vector3.forward);
                _returnRotationDirection = Vector3.back;

            }
            if (LeftMoving == false && RightMoving == false && PkMove == false)
            {
                ReturnToStartPositionRotation();
            }

        }
    }
    //add to leftmove event pointer down & up
    public void MoveLeft()
    {
        LeftMoving = !LeftMoving;
    }

    //add to Rightmove event pointer down & up
    public void MoveRight()
    {
        RightMoving = !RightMoving;
    }
    private void FixCharterRotateByDirection(Vector3 direction)
    {
        if (_angle < MaxAngle)
            _playerRotate.Rotate(direction, RotateSpeed);
    }

    private void ReturnToStartPositionRotation()
    {
        _playerRotate.Rotate(_returnRotationDirection, RotateSpeed);
        if (_angle < _startAngle + 4)
        {
            _playerRotate.localEulerAngles = _startRotation;
            _returnRotationDirection = Vector3.zero;
        }
    }
    
    public void PkMoveControll()
    {
        var direction = Input.GetAxis("Horizontal");
        if (PkMove)
        {
            if (Input.GetButton("Horizontal")) {
                if (direction > 0)
                {
                    direction = 1;
                }
                if (direction < 0)
                {
                    direction = -1;
                }
                _charterMove.Move(new Vector3(direction,0,0) * TurnSpeed);
                FixCharterRotateByDirection(new Vector3(0,0,direction));
                _returnRotationDirection = new Vector3(0,0,direction * -1);
            }
            if (Input.GetButtonUp("Horizontal"))
            {
                _returnRotation = true;
            }
            if (Input.GetButtonDown("Horizontal"))
            {
                _returnRotation = false;
            }
            if (_returnRotation)
            {
                ReturnToStartPositionRotation();
            }
        }
    }
    public float PlayerSpeed
    {
        get { return Speed; }
        set { Speed = value; }
    }
}
