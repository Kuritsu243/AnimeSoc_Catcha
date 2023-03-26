using UnityEngine;

public class Shop : MonoBehaviour
{
    public Player PlayerScript;

    public GameObject ShopMenu;

    public bool timeractive;
    public float timer;

    public bool ShopOpen;

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
        if(PlayerScript.mwep > 0)
        {
            PlayerScript.mwep--;
            PlayerScript.FoodGot++;
        }
    }

}
