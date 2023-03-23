using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cat", menuName = "Cats")]
public class cats : ScriptableObject
{
    public enum CatType
    {
        Pallas,
        Burger,
        Slug,
        Pickl,
        Sus
    }
    
    
    [SerializeField] public string catName;
    [SerializeField] public Sprite catSprite;
    [SerializeField] public CatType catType;
}
