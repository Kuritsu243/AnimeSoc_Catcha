using UnityEngine;
using System.Collections;
using TMPro;

public class Player : MonoBehaviour
{

    public int mwep;
    public TextMeshProUGUI MwepText;

    public int FoodGot;

    public void Update()
    {
        MwepText.text = mwep.ToString();
    }

}
