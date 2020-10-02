using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerScript : MonoBehaviour
{
    private int currLives = LivesUI.numLives;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Balloon"))
        {
            currLives -= 1;
            LivesUI.numLives = currLives;
            Destroy(coll.gameObject);
            if (currLives == 0) {
                GameObject gm = GameObject.FindWithTag("GameController");
                gm.GetComponent<GameManager>().LoseGame();
            }
        }
    }
}
