﻿using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int heath;
    int damage;
    int pushForce;

    private void Start()
    {
        heath = 2;
        damage = 1;
        pushForce = 5;
    }

    public int Health
    {
        get => heath;
        set
        {
            heath = value;
            if (heath <= 0) Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Health -= damage;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * pushForce, ForceMode2D.Impulse);
        }        
    }

}
