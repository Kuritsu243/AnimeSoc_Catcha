using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class catsController : MonoBehaviour
{
    [SerializeField] private List<cats> catTypes; // list of all the types
    [SerializeField] private cats.CatType catVariant; // the current type of cat assigned to this
    [SerializeField] private string catName;
    

    public cats.CatType CatVariant
    {
        get => catVariant;
        set => catVariant = value;
    }

    public string CatName
    {
        get => catName;
        set => catName = value;
    }
    // Start is called before the first frame update

    public void Initialize(cats.CatType newCatType, string newCatName)
    {
        catVariant = newCatType;
        catName = newCatName;
    }
}
