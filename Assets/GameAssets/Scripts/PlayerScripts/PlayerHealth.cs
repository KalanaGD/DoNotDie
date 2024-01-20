using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] Slider _healthSlider;

    private Animator _anim;
    string death = "death";
    string damage = "damage";

    private Transform _enemy1; 
    private Transform _enemy2; 
    [SerializeField] private Transform _player;

    private float _maxHealth = 100f;
    private float _currentHealth;

    private float _e1damageAmount = 1f;
    private float _e2damageAmount = 3f;

    private float _distanceToEnemy = 1f;
    private float _nextAttackEnemy1;
    private float _nextAttackEnemy2;
    private float _attackRate1;
    private float _attackRate2;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        
        _currentHealth = _maxHealth;
       _healthSlider.maxValue = _maxHealth;

        _attackRate1 = 0.5f;
        _attackRate2 = 1f;
        _nextAttackEnemy1 = Time.time;
        _nextAttackEnemy2 = Time.time;
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy1") != null)
        {
           _enemy1 = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Transform>();
            
        }
        if(GameObject.FindGameObjectWithTag("Enemy2") != null)
        {
           _enemy2 = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Transform>();
        }

        TakeDamage();
    }

   


    private void TakeDamage()
    {
   
        if (_enemy1 != null && _player != null)
        {
            //check player and enemy position and check if time to attack 
            if (Vector2.Distance(_player.position, _enemy1.position) <= _distanceToEnemy && Time.time > _nextAttackEnemy1)
            {
                _currentHealth -= _e1damageAmount;
                
                _healthSlider.value = _currentHealth;
                _anim.SetTrigger(damage);
   
                _nextAttackEnemy1 = Time.time + _attackRate1;
   
                if (_currentHealth <= 0)
                {
                    _anim.SetTrigger(death);
                    Destroy(this.gameObject, 2f);
                }
            }
        }
        if (_enemy2 != null && _player != null)
        {
            //check player and enemy position and check if time to attack 
            if (Vector2.Distance(_player.position, _enemy2.position) <= _distanceToEnemy && Time.time > _nextAttackEnemy2)
            {
                _currentHealth -= _e2damageAmount;

                _healthSlider.value = _currentHealth;
                _anim.SetTrigger(damage);

                _nextAttackEnemy2 = Time.time + _attackRate2;

                if (_currentHealth <= 0)
                {
                    _anim.SetTrigger(death);
                    Destroy(this.gameObject, 2f);
                }
            }
        }
    }
}
