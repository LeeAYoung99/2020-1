using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    public Slider musicTime;
    public Text musicText;



    // Start is called before the first frame update
    void Start()
    {
        musicText.text = musicTime.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        musicText.text = musicTime.value.ToString();
    }
}
