using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int gold = 150;
    public int goldNaturalGainAmount = 10;
    public float goldInterval = 2f;
    float goldTimer = 0f;

    public GameObject qMonkeyObj;
    public GameObject wMonkeyObj;
    public GameObject eMonkeyObj;
    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (goldTimer <= 0)
        {
            GainGold(goldNaturalGainAmount);
        }
        else
        {
            goldTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetKey(KeyCode.Q)) {
                if (gold >= 50)
                {
                gold -= 50;
                GoldUI.goldValue -= 50;
                Debug.Log("You spent 50 gold to buy a monkey. You now have " + gold + " gold left.");

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                mousePos.z = 0f;

                Instantiate(qMonkeyObj, mousePos, Quaternion.identity);
                }
            }
            else if (Input.GetKey(KeyCode.E)) {
                if (gold >= 100)
                {
                gold -= 100;
                GoldUI.goldValue -= 100;
                Debug.Log("You spent 80 gold to buy a sniper monkey. You now have " + gold + " gold left.");

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                mousePos.z = 0f;

                Instantiate(wMonkeyObj, mousePos, Quaternion.identity);
                }
            }
            else if (Input.GetKey(KeyCode.W)) {
                if (gold >= 70)
                {
                gold -= 70;
                GoldUI.goldValue -= 70;
                Debug.Log("You spent 60 gold to buy a quick monkey. You now have " + gold + " gold left.");

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                mousePos.z = 0f;

                Instantiate(eMonkeyObj, mousePos, Quaternion.identity);
                }
            }
            
            else
            {
                Debug.Log("You have " + gold + " gold. You don't have enough gold to buy a monkey.");
            }
        }
    }

    private void GainGold(int amount)
    {
        gold += amount;
        Debug.Log("You now have " + gold + " gold.");

        GoldUI.goldValue += amount;

        goldTimer = goldInterval;
    }
}
