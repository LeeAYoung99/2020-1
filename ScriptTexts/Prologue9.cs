using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue9 : MonoBehaviour
{
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>2f)
        {
            SceneManager.LoadScene("Prologue10");
        }
        

    }
}
