using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public static int goldValue = 100;
    Text gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = "Gold:" + goldValue;
    }
}
