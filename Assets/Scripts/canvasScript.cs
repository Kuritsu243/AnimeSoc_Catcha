using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{
    [Header("Cat Count Menu")] // add more variant texts later
    [SerializeField] private Button showCatCountBtn;
    [SerializeField] private GameObject showCatCountMenu;
    [SerializeField] private TextMeshProUGUI catVariantOneText;
    [SerializeField] private TextMeshProUGUI totalCatsText;
    
    
    private bool _isShowingCatCountMenu;

    // replace this var names later
    private int _catType1;
    private int _catType2;
    private int _catType3;
    private int _catType4;
    private int _catType5;
    private void Start()
    {
        showCatCountBtn.onClick.AddListener(ToggleCatCount); // binding done in script instead of in inspector
        showCatCountMenu.SetActive(false); // disable the UI 
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    private void ToggleCatCount()
    {
        _isShowingCatCountMenu = !_isShowingCatCountMenu; // if true = false if false = true
        showCatCountMenu.SetActive(_isShowingCatCountMenu); // toggle according to above
        GetCatCount();
    }

    private void GetCatCount()
    {
        ClearCatCount();
        var catsInScene = GameObject.FindGameObjectsWithTag("Cats"); // find all cats, will implement a more efficient way of doing this later
        foreach (var catGameObject in catsInScene)
        {
            var controller = catGameObject.GetComponent<catsController>();
            switch (controller.CatVariant)
            {
                case cats.CatType.Burger:
                    _catType1++;
                    break;
                case cats.CatType.Pallas:
                    _catType2++;
                    break;
                case cats.CatType.Pickl:
                    _catType3++;
                    break;
                case cats.CatType.Slug:
                    _catType4++;
                    break;
                case cats.CatType.Sus:
                    _catType5++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        totalCatsText.text = (_catType1 + _catType2 + _catType3 + _catType4 + _catType5).ToString();
        catVariantOneText.text = _catType1.ToString();

    }

    private void ClearCatCount()
    {
        _catType1 = 0;
        _catType2 = 0;
        _catType3 = 0;
        _catType4 = 0;
        _catType5 = 0;
    }
}
