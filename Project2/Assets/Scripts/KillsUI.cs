using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class KillsUI : MonoBehaviour
{
    public static int numKills = 0;
    Text kills;
    // Start is called before the first frame update
    void Start()
    {
        kills = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        kills.text = "Kills:" + numKills;
        if (numKills + (5 - LivesUI.numLives) == 40 && LivesUI.numLives > 0) {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().WinGame();
        }
    }
}
