using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //check if coll is the player
        if (coll.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>().player = coll.transform;
            Debug.Log("SEE PLAYER RUN AT PLAYER");
        }
    }
}
