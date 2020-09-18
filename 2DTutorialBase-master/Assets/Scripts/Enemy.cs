using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    #endregion

    #region Attack_variables
    public float explosionDamage;
    public float explosionRadius;
    public GameObject explosionObj;
    #endregion

    #region Physics_components
    protected Rigidbody2D EnemyRB;
    #endregion

    #region Targeting_varaibles
    public Transform player;
    #endregion


    #region Health_variables
    public float maxhealth;
    protected float currHealth;
    #endregion

    #region Unity_functions
    // runs once on creation
    protected virtual void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();

        currHealth = maxhealth;
    }

    //runs once every frame
    protected virtual void Update()
    {
        //check if we know where the player is
        if (player == null)
        {
            return;
        }

        Move();
    }
    #endregion

    #region Movement_function
    protected virtual void Move()
    {
        Vector2 direction = player.position - transform.position;

        EnemyRB.velocity = direction.normalized * movespeed;
    }
    #endregion

    #region Attack_function
    private void Explode()
    {
        // call audioManager for explosion
        FindObjectOfType<AudioManager>().Play("Explosion");

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player"))
            {
                //Cause damage
                Debug.Log("Hit player with explosion");

                //spawn explosion prefab
                Instantiate(explosionObj, transform.position, transform.rotation);
                hit.transform.GetComponent<PlayerController2>().TakeDamage(explosionDamage);
                Destroy(this.gameObject);
            }
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            {
                Explode();
            }
    }

    #endregion

    #region Health_functions

    //enemy takes damage based on value param
    public virtual void TakeDamage(float value)
    {
        // call audioManager for taking damage
        FindObjectOfType<AudioManager>().Play("BatHurt");

        //Decrement health
        currHealth -= value;
        Debug.Log("Health is now " + currHealth.ToString());

        //change UI

        //Check if dead
        if (currHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Debug.Log("Enemy is killed. Get 1 score.");
        ScoreScript.scoreValue += 1;

        // Destory game object
        Destroy(this.gameObject);
    }
    #endregion
}


