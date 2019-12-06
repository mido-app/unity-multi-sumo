using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject fallObject = null;
    private int fallCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text fallText = fallObject.GetComponent<Text>();
        fallText.text = "Fall Count:" + fallCount;
    }

    public void AddFallCount()
    {
        fallCount++;
    }
}
