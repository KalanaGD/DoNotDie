using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private Animator _anim;

    private float _playerSpeed = 2.5f;
    private float _playerBoostSpeed = 4.5f;

    private float _vertical;
    private float _horizontal;
    
    [HideInInspector] public bool _isFliped = false;
    private bool _walking = false;

    string walk ="walk";
    string run = "run";


    private void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        PlayerFlip();
    }


    private void PlayerMovement()
    {
        Vector2 _movement = new Vector2(_horizontal, _vertical).normalized;

        //walk
        _playerRB.velocity = _movement * _playerSpeed;

        //run
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _playerRB.velocity = _movement * _playerBoostSpeed;

            if(_walking )
            {
                _anim.SetBool(run, true);
            }
        }
        else
        {
            _anim.SetBool(run, false);
        }
    }

    public void PlayerFlip()
    {

        Vector3 _mouseInput = Input.mousePosition;
        Vector3 _mousepos = Camera.main.ScreenToWorldPoint(_mouseInput);

        if(_mousepos.x <= transform.position.x)
        {
            Vector3 vector3 = new Vector3(-1, 1, 1);
            transform.localScale = vector3;
            _isFliped = true;
        }
        else
        {
            Vector3 vector3 = new Vector3(1, 1, 1);
            transform.localScale = vector3;
            _isFliped = false;
        }

        if (_playerRB.velocity.magnitude  != 0)
        {
            _walking = true;
        }
        else
        {
            _walking = false;
        }

        if (_horizontal == 0 && _vertical == 0)
        {
            _walking = false;
        }

        if (_walking == true)
        {
            _anim.SetBool(walk, true);
        }
        if (_walking == false)
        {
            _anim.SetBool(walk, false);
        }
    }
}
