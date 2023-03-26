using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cat : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public float HungerCounter = 1; //temporary variable name i couldnt think of something else more suitable
    public float PlayCounter = 1;

    public Slider PlayMeter;
    public Slider HungerMeter;

    public GameObject Canvas;

    public Player playerscript;

    private IEnumerator coroutine1;
    private IEnumerator coroutine2;

    private void Start()
    {
        coroutine1 = GoldGeneration(2.0f);
        coroutine2 = StatusDecrease(15f);
        StartCoroutine(coroutine1);
        StartCoroutine(coroutine2);
    }

    public void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
        {

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }

            Debug.Log("Cat Clicked");
            if (hit.collider.gameObject)//wip 
            {
                Canvas.SetActive(true);
            }
        }

        PlayMeter.value = PlayCounter;
        HungerMeter.value = HungerCounter;

        if(HungerCounter < 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator GoldGeneration(float waitTime)
    {
        while(true)
        {
            playerscript.mwep++;
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }

    private IEnumerator StatusDecrease(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            HungerCounter = HungerCounter - 0.1f;
            PlayCounter = PlayCounter - 0.1f;
        }
    }

    public void Feed()
    {
        if(playerscript.FoodGot > 0)
        {
            HungerCounter = HungerCounter + 0.2f;
            playerscript.FoodGot--;
        }
    }


    public void Play()
    {
        PlayCounter = PlayCounter + 0.2f;
        playerscript.FoodGot--;
    }
}
