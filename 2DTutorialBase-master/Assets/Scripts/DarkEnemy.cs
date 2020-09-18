using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnemy : Enemy
{
    #region Movement_variables
    public float moveInterval = 1/2;
    float moveTimer;
    public GameObject enemyObj;
    #endregion

    #region Unity_functions
    // runs once on creation
    override protected void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();

        currHealth = maxhealth;

        moveTimer = 1;
    }

    //runs once every frame
    override protected void Update()
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
    override protected void Move()
    {
        Debug.Log("moveTimer is now " + moveTimer.ToString());

        Vector2 direction = player.position - transform.position;
        if (moveTimer <= 0)
        {
            EnemyRB.velocity = direction.normalized * movespeed;
            moveTimer -= Time.deltaTime;
            if (moveTimer <= -moveInterval)
            {
                moveTimer = moveInterval;
            }
        }
        else
        {
            EnemyRB.velocity = direction * 0;
            moveTimer -= Time.deltaTime;
        }
    }
    #endregion

    #region Health_functions

    override public void TakeDamage(float value)
    {
        // call audioManager for taking damage
        FindObjectOfType<AudioManager>().Play("BatHurt");

        //Decrement health
        currHealth -= value;
        Debug.Log("Health is now " + currHealth.ToString());

        //spawn another enemy
        Instantiate(enemyObj, transform.position, transform.rotation);

        //change UI

        //Check if dead
        if (currHealth <= 0)
        {
            Die();
        }
    }
    #endregion
}
