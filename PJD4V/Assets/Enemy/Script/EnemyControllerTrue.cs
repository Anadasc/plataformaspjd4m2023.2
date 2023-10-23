using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyControllerTrue : MonoBehaviour
{
    public int maxEnergy;
    public int damage;
    public float moveSpeed;
    public bool useTransform;
    public bool shouldFlip;

    public GameObject p1;
    public GameObject p2;
    public GameObject LL;
    public GameObject LR;

    private int _currentEnergy;

    private Animator _animator;

    private bool _isAlive;

    private Collider2D _collider2D;
    
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();

        _isAlive = true;
        
        _currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAlive) Move();
    }

    private void Move()
    {
        
    }

    public void TakeEnergy(int damage)
    {
        _currentEnergy -= damage;

        if (_currentEnergy <= 0)
        {
            //TODO: Gerenciar morte  do inimigo
            _currentEnergy = 0;
            //Destroy(gameObject);
            _isAlive = false;
            _collider2D.enabled = false;
            _animator.Play("Dead");
            _audioSource.Play();
        }

        if (_currentEnergy > maxEnergy) _currentEnergy = maxEnergy;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
