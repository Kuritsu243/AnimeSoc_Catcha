using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public player PlayerScript;

    public GameObject ShopMenu;

    public bool timeractive;
    public float timer;

    public bool ShopOpen;

    private void Start()
    {

        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        ShopMenu.SetActive(false);
        ShopOpen = false;
    }

    public void Update()
    {
        if(timeractive)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        if(timer > 0.5f)
        {
            timeractive = false;
            timer = 0;
        }
    }
    public void ShopButton()
    {
        if(ShopOpen && timeractive == false)
        {
            ShopMenu.SetActive(false);
            ShopOpen = false;
            timeractive = true;

        }

        if (ShopOpen == false && timeractive == false)
        {
            ShopMenu.SetActive(true);
            ShopOpen = true;
            timeractive = true;
        }

    }

    public void BuyYummies()
    {
        if (PlayerScript.Money <= 0) return;
        PlayerScript.RemoveMoney(1);
        PlayerScript.AddFood(1);
    }

}
