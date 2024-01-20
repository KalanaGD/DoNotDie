using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _target;

    [SerializeField] private float _bulletSpeed = 8;
    private float _distanceToMouse = 0.2f;


    private void Start()
    {
        //get mouse position to _target
        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        Firing();
        DestroyBullet();
    }


    private void Firing()
    {
        //bullet moveTowards the target point
        transform.position = Vector2.MoveTowards(transform.position,_target, _bulletSpeed* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        //this part using in Enemy1,2  
        //damage count 1 both
        if (target.gameObject.TryGetComponent<Enemy1>(out Enemy1 enemyComponent1))
        {
            enemyComponent1.TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (target.gameObject.TryGetComponent<Enemy2>(out Enemy2 enemyComponent2))
        {
            enemyComponent2.TakeDamage(1);
            Destroy(this.gameObject);
        }

    }

    private void DestroyBullet()
    {
        if (Vector2.Distance(transform.position,_target) < _distanceToMouse)
        {
            //if bullet near with the mouse point destroy it
            Destroy(this.gameObject);
        }
    }
}
