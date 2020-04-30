using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public static bool isPlaying;
    // Start is called before the first frame update

    void Awake()
    {
        isPlaying = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayPause()
    {
        if(isPlaying == false)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }
}
