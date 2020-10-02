using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
       
    public Vector2 currDirection;
    #endregion

    #region Physics_components
    Rigidbody2D EnemyRB;
    #endregion

    #region Health_variables
    public float maxHealth;
    float currHealth;
    #endregion

    #region Unity_functions
    //runs once on creation
    private void Awake() {
        
        EnemyRB = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
        currDirection = Vector2.down;
    }

    private void Update()
    {
        Move();
    }
    #endregion

    #region Movement_functions
    private void Move() 
    {
        EnemyRB.velocity = currDirection * movespeed;
    }
    #endregion

    #region Health_functions
    public void TakeDamage(float value)
    {
        currHealth -= value;

        if (currHealth <= 0) {
            Die();
        }
    }
    private void Die() {
        KillsUI.numKills += 1;
        Destroy(this.gameObject);
    }
    #endregion

    
}
