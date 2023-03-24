using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class catsController : MonoBehaviour
{
    [SerializeField] private List<cats> catTypes; // list of all the types
    [SerializeField] private cats.CatType catVariant; // the current type of cat assigned to this


    public cats.CatType CatVariant
    {
        get => catVariant;
        set => catVariant = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
