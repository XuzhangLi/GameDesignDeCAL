using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTriggerScript : MonoBehaviour
{

    public Vector2 newDirection;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Balloon"))
        {
            coll.transform.GetComponent<Balloon>().currDirection = newDirection;
        }
    }
}
