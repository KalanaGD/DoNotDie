using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAimWeapon : MonoBehaviour
{
    private Vector2 _direction;
    private Player _player;
    private bool other;


    private void Update()
    {
        Vector3 _mouseInput = Input.mousePosition;
        Vector3 _mousepos = Camera.main.ScreenToWorldPoint(_mouseInput);
        
        _direction = new Vector2(_mousepos.x - transform.position.x, _mousepos.y - transform.position.y);


        IsFliped();
    }

    private void IsFliped()
    {
        _player = FindObjectOfType<Player>();

        other = _player._isFliped;

        if (other == true)
        {
            transform.right = -_direction;
        }
        if(other == false)
        {
            transform.right = _direction;
        }
    } 
}
