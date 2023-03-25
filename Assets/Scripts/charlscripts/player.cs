using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class player : MonoBehaviour
{
    private canvasScript _canvasScript;
    [SerializeField] private GameObject emptyCatGo;

    private string[] _defaultCatNames = new string[]
    {
        "Amber", "Arthur", "Arya", "Atticus", "Aurora", "Ava", "Baby Girl", "Barney", "Basil", "Benji", "Billy",
        "Biscuit", "Blaze", "Blu", "Bobby", "Boomer", "Bootsie", "Boris", "Bowie", "Bubbles", "Bug", "Bunny",
        "Buttercup", "Butters", "Calvin", "Casey", "Cash", "Cassie", "Chance", "Charlie", "Chase", "Chewy", "Chip",
        "Cinnamon", "Clover", "Cocoa", "Cody", "Cuddles", "Cupcake", "Dash", "Diamond", "Diego", "Diesel", "Dixie",
        "Domino", "Dora", "Duchess", "Duke", "Echo", "Eddie", "Elvis", "Ember", "Emily", "Emmy", "Ernie", "Evie",
        "Finnegan", "Freddie", "Gary", "Georgie", "Ghost", "Guy", "Hank", "Harvey", "Hobbes", "Hope", "Indy",
        "Isabella", "Jerry", "Juno", "Kali", "Karma", "Kat", "Kevin", "Kit", "Kiwi", "Kona", "Lady", "Larry", "Lilo",
        "Link", "Linus", "Logan", "Lucifer", "Luna", "Mabel", "Mac", "Macy", "Maddie", "Magic", "Maui", "Maverick",
        "Maxwell", "Mikey", "Mila", "Miles", "Misha", "Mo", "Moe", "Mojo", "Monster", "Monty", "Moo", "Moon", "Mowgli",
        "Munchkin", "Nacho", "Neko", "Nemo", "Niko", "Nina", "Noah", "Noodle", "Norman", "Nyx", "Odin", "Oliver",
        "Opie", "Orion", "Panda", "Panther", "Parker", "Pebbles", "Pete", "Phoenix", "Pip", "Pippin", "Poe", "Polly",
        "Quinn", "Remi", "Remy", "Rex", "Ringo", "Ripley", "Rocket", "Rory", "Roscoe", "Rose", "Roxie", "Rudy", "Rufus",
        "Sabrina", "Sammie", "Sampson", "Sandy", "Sheba", "Shelby", "Sheldon", "Skittles", "Sky", "Sonny", "Sox",
        "Spencer", "Spike", "Stanley", "Stitch", "Suki", "Sully", "Sunshine", "Sweet Pea", "Sweetie", "Tabby",
        "Tabitha", "Thunder", "Tilly", "Tink", "Tinkerbell", "Tiny", "Tony", "Toothless", "Trouble", "Vader", "Waffles",
        "Walter", "Whiskey", "Willie", "Wilson", "Xena", "Yoshi", "Yuki", "Zeke"
    };

    private int _countOfCatNames;
    // Start is called before the first frame update
    private void Start()
    {
        _canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<canvasScript>();
        _countOfCatNames = _defaultCatNames.Length;
        // this is to test the rng 
        // for (var i = 0; i < 5; i++)
        // {
        //     Debug.Log(GenerateCatChoice());
        // }
    }

    
    // this will be private once fully implemented
    public void AddNewCat()
    {
        var newCatType = GenerateCatChoice();
        var newCatName = GenerateCatName();
        var newCat = Instantiate(emptyCatGo, Vector2.zero, Quaternion.identity);
        var newCatScript = newCat.GetComponent<catsController>();
        newCatScript.Initialize(newCatType, newCatName);
        _canvasScript.ToggleNewCatUI(newCatType, newCatName);

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

    private string GenerateCatName()
    {

        var index = Random.Range(0, _countOfCatNames-1);
        return _defaultCatNames[index];
    }
    
}
