using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public float HungerCounter; //temporary variable name i couldnt think of something else more suitable
    public float PlayCounter;

    public Slider PlayMeter;
    public Slider HungerMeter;

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //make the funmeter and hunger meter appear
            //make feed and play button appear


        }

        PlayMeter.value = PlayCounter;
        HungerMeter.value = HungerCounter;
    }

}
