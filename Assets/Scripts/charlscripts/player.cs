using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < 5; i++)
        {
            Debug.Log(GenerateCatChoice());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewCat()
    {
        
    }

    private static cats.CatType GenerateCatChoice()
    {
        // var count = System.Enum.GetValues(typeof(cats.CatType)).Length;
        var index = Random.Range(0, 100);

        return index switch
        {
            (<= 20) => cats.CatType.Burger,
            (> 20 and <= 40) => cats.CatType.Pallas,
            (> 40 and <= 60) => cats.CatType.Pickl,
            (> 60 and <= 80) => cats.CatType.Slug,
            (> 80 and <= 100) => cats.CatType.Sus,
            _ => cats.CatType.Burger
        };
    }
    
}
