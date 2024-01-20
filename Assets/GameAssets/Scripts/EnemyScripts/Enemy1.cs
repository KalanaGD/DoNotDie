using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    
    [HideInInspector] public EnemyHealth _healthBar;

    private Animator _anim;
    private Rigidbody2D _rb;

    string walk = "walk";
    string attack = "attack";
    string death = "death";

    private bool _walking = false;
     private Transform _playerPos;
    [SerializeField] private float _enemy1Speed = 1f;
    private float _distanceToPlayer = 5f;
    private float _maxHealth = 5f;
    private float _currentHealth;
    private float _stoppingDistance = 1f;
    private Vector3 _currentScale;


    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _healthBar = GetComponent<EnemyHealth>();

        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);

        _currentScale = transform.localScale;
    }

    private void Update()
    {
        GetPlayerPosition();
        FollowPlayer();
        Animations();
        FlipEnemy();
        StopDistance();
    }

    private void GetPlayerPosition()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    private void FollowPlayer()
    {
        if( _playerPos != null )
        {
            //check the distance between player and enemy 
            if (Vector2.Distance(transform.position, _playerPos.position) < _distanceToPlayer)
            {
                //enemy moveTowards the player position
                transform.position = Vector2.MoveTowards(transform.position, _playerPos.position, _enemy1Speed * Time.deltaTime);
                _walking = true;
            }
            if (Vector2.Distance(transform.position, _playerPos.position) > _distanceToPlayer)
            {
                _walking = false;
            }
        }
    }

    private void FlipEnemy()
    {
        
        if (_playerPos != null )
        {
            Vector3 _directionToPlayer = _playerPos.position - transform.position;

            if (_directionToPlayer.x != 0)
            {
                _body.transform.localScale = new Vector3(Mathf.Sign(_directionToPlayer.x) * _currentScale.x, _currentScale.y, _currentScale.z);
            }
        }
    }

    private void StopDistance()
    {
        if(_playerPos != null)
        {
            //check enemy and player position 
            if (Vector2.Distance(transform.position, _playerPos.position) <= _stoppingDistance)
            {
                _enemy1Speed = 0;
                _anim.SetBool(attack, true);
                _anim.SetBool(walk, false);
            }
            if (Vector2.Distance(transform.position, _playerPos.position) > _stoppingDistance)
            {
                _enemy1Speed = 1f;
                _anim.SetBool(attack, false);
            }
        }
        
    }

    private void Animations()
    {
        if (_walking == true)
        {
            _anim.SetBool(walk, true);
        }
        if (_walking == false)
        {
            _anim.SetBool(walk, false);
        }
        if (_playerPos == null)
        {
            _anim.SetBool(attack, false);
            _anim.SetBool(walk, false);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        _healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            _anim.SetTrigger(death);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
