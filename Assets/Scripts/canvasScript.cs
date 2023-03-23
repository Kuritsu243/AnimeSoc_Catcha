using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class canvasScript : MonoBehaviour
{
    [SerializeField] private Button _showCatCountBtn;
    // Start is called before the first frame update
    private void Start()
    {
        _showCatCountBtn.RegisterCallback<ClickEvent>(ToggleCatCount);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    private void ToggleCatCount(ClickEvent evt)
    {
        Debug.Log("This button has been clicked");
    }
}
