using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class catsController : MonoBehaviour
{
    [SerializeField] private List<cats> catTypes; // list of all the types
    [SerializeField] private cats.CatType catVariant; // the current type of cat assigned to this
    [SerializeField] private string catName;
    [SerializeField] private Slider playMeter;
    [SerializeField] private Slider hungerMeter;
    [SerializeField] private Button feedBtn;
    [SerializeField] private Button playBtn;
    [SerializeField] private Sprite[] catVar1Sprites;
    
    
    
    private Camera _mainCamera;
    private GameObject _player;
    private Canvas _catCanvas;
    private player _playerScript;
    private SpriteRenderer _spriteRenderer;

    private float _hungerCounter = 1;
    private float _playCounter = 1;

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
    
    
    // merging with cats code (if I refactor this too much I apologize)
    // WIP
    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // get main camera
        _player = GameObject.FindGameObjectWithTag("Player"); // find player
        _playerScript = _player.GetComponent<player>(); // get player script
        _catCanvas = GetComponentInChildren<Canvas>(); // to avoid having to assign the canvas in inspector
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        // coroutine1 = GoldGeneration(2.0f);
        // coroutine2 = StatusDecrease(15f);
        // StartCoroutine(coroutine1);
        // StartCoroutine(coroutine2);
        
        // charl additions
        StartCoroutine(GoldGeneration(2.0f));
        StartCoroutine(StatusDecrease(15f));
        StartCoroutine(ChangeSprite(5f));
        StartCoroutine(RandomizeMovement(3f, 1f));
        playBtn.onClick.AddListener(Play); // add button listener (avoids doing it in editor)
        feedBtn.onClick.AddListener(Feed); // add button listener (avoids doing it in editor)
    }
    

    private void FixedUpdate()
    {
        playMeter.value = _playCounter; 
        hungerMeter.value = _hungerCounter;
        
        if (_hungerCounter <= 0)
            Destroy(gameObject);
        
        // var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //
        // if (Physics2D.Raycast(mousePos, Vector2.zero))
        // {
        //     _catCanvas.gameObject.SetActive(true);
        //     StopCoroutine(WaitBeforeHidingUI(0.2f));
        // }
        // else
        //     StartCoroutine(WaitBeforeHidingUI(0.2f));
        //


    }

    private IEnumerator GoldGeneration(float waitTime)
    {
        _playerScript.AddMoney(1);
        yield return new WaitForSecondsRealtime(waitTime);
        StartCoroutine(GoldGeneration(waitTime)); // recursive
    }

    private IEnumerator WaitBeforeHidingUI(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        _catCanvas.gameObject.SetActive(false);
    }

    private IEnumerator StatusDecrease(float waitTime)
    {
        _hungerCounter -= 0.1f;
        _playCounter -= 0.1f;
        yield return new WaitForSecondsRealtime(waitTime);
        StartCoroutine(StatusDecrease(waitTime)); // recursive
    }

    private IEnumerator ChangeSprite(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        switch (catVariant)
        {
            case cats.CatType.Pallas:
                var index = Random.Range(0, catVar1Sprites.Length - 1);
                var newSprite = catVar1Sprites[index];
                _spriteRenderer.sprite = newSprite;
                break;
            case cats.CatType.Burger:
                break;
            case cats.CatType.Slug:
                break;
            case cats.CatType.Pickl:
                break;
            case cats.CatType.Sus:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        StartCoroutine(ChangeSprite(waitTime));
    }

    private IEnumerator RandomizeMovement(float waitTime, float moveSpeed)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        var newPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        transform.position = Vector2.MoveTowards(transform.position, newPos, 2f);
        StartCoroutine(RandomizeMovement(waitTime, moveSpeed));
    }

    private void Feed()
    {
        if (_playerScript.Food <= 0) return;
        _hungerCounter += 0.2f;
        _playerScript.ConsumeFood(1);
    }

    private void Play()
    {
        _playCounter += 0.2f;
    }
    
    
    
    
    
    
    // public void FixedUpdate()
    // {
    //     //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
    //     // ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting
    //     var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
    //     
    //     // added var before hit below here to evade having to define it as a pre-existing var
    //     if (Physics.Raycast(ray, out var hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
    //     {
    //
    //         if (hit.collider != null)
    //         {
    //             Debug.Log(hit.collider.name);
    //         }
    //
    //         Debug.Log("Cat Clicked");
    //         if (hit.collider.gameObject)//wip 
    //         {
    //             Canvas.SetActive(true);
    //         }
    //     }
    //
    //     PlayMeter.value = PlayCounter;
    //     HungerMeter.value = HungerCounter;
    //
    //     if(HungerCounter < 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    //
    // private IEnumerator GoldGeneration(float waitTime)
    // {
    //     while(true)
    //     {
    //         playerscript.mwep++;
    //         yield return new WaitForSecondsRealtime(waitTime);
    //     }
    // }
    //
    // private IEnumerator StatusDecrease(float waitTime)
    // {
    //     while(true)
    //     {
    //         yield return new WaitForSecondsRealtime(waitTime);
    //         HungerCounter = HungerCounter - 0.1f;
    //         PlayCounter = PlayCounter - 0.1f;
    //     }
    // }
    //
    // public void Feed()
    // {
    //     if(playerscript.FoodGot > 0)
    //     {
    //         HungerCounter = HungerCounter + 0.2f;
    //         playerscript.FoodGot--;
    //     }
    // }
    //
    //
    // public void Play()
    // {
    //     PlayCounter = PlayCounter + 0.2f;
    //     playerscript.FoodGot--;
    // }
    //
}
