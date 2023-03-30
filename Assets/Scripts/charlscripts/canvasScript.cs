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
    [SerializeField] private Button addCatsBtn; // THIS IS TEMPORARY FOR TESTING
    [SerializeField] private GameObject showCatCountMenu;
    [SerializeField] private TextMeshProUGUI catVariantOneText;
    [SerializeField] private TextMeshProUGUI catVariantTwoText;
    [SerializeField] private TextMeshProUGUI catVariantThreeText;
    [SerializeField] private TextMeshProUGUI catVariantFourText;
    [SerializeField] private TextMeshProUGUI catVariantFiveText;
    [SerializeField] private TextMeshProUGUI totalCatsText;
    [Header("New Cat Menu")]
    [SerializeField] private GameObject showNewCatMenu;
    [SerializeField] private TextMeshProUGUI newCatNameText;
    [SerializeField] private TextMeshProUGUI newCatTypeText;
    [SerializeField] private TextMeshProUGUI newCatTotalText;
    [SerializeField] private float timeToShowUI;
    [Header("Currency and Food")] 
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI foodText;
    

    
    
    
    
    
    private GameObject _player;
    private player _playerScript;
    private bool _isShowingCatCountMenu;

    // replace this var names later
    private int _catType1;
    private int _catType2;
    private int _catType3;
    private int _catType4;
    private int _catType5;
    private void Start()
    {

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerScript = _player.GetComponent<player>();
        showCatCountBtn.onClick.AddListener(ToggleCatCount); // binding done in script instead of in inspector
        showCatCountMenu.SetActive(false); // disable the UI 
        showNewCatMenu.SetActive(false);
        
        // TEMP
        addCatsBtn.onClick.AddListener(_playerScript.AddNewCat);
    }

    public void ToggleNewCatUI(cats.CatType newCatType, string newCatName)
    {
        newCatNameText.text = "Cat Name: " + newCatName;
        newCatTypeText.text = "Cat Type: " + newCatType;
        GetCatCount();
        newCatTotalText.text = totalCatsText.text;
        StartCoroutine(ToggleUI(timeToShowUI, showNewCatMenu));
    }

    private static IEnumerator ToggleUI(float duration, GameObject uiObject)
    {
        uiObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        uiObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        currencyText.text = "Money: " + _playerScript.Money;
        foodText.text = "Food: " + _playerScript.Food;
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

        totalCatsText.text = "Total Cats: " + (_catType1 + _catType2 + _catType3 + _catType4 + _catType5);
        catVariantOneText.text = _catType1.ToString();
        catVariantTwoText.text = _catType2.ToString();
        catVariantThreeText.text = _catType3.ToString();
        catVariantFourText.text = _catType4.ToString();
        catVariantFiveText.text = _catType5.ToString();

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
