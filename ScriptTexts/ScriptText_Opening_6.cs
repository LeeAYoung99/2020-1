using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;


public class ScriptText_Opening_6 : MonoBehaviour
{
    private Text St;

    public string currentText;
    string myText;

    public bool textActive; //텍스트가 타자 작동중인지 아닌지에 대한 함수입니다.

    int i;

    public AudioSource audioSource;
    public AudioClip bgm;



    // Start is called before the first frame update
    void Start()
    {
        myText = "부장님이 맡긴 일이 끝나면, 이 일도 맡아줘.\n이건 쉽게 끝나지 않을거야.";
        currentText = "";
        textActive = true;
        St = GameObject.Find("Script").GetComponent<Text>();

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = bgm; //오디오에 bgm이라는 파일 연결
        audioSource.playOnAwake = false;



    }
    /*
     IEnumerator Sleep(float time)
    {
      
        yield return new WaitForSeconds(time);

    }
         */


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textActive == true)
            {
                textActive = false;
            }
            else
            {
                //Debug.Log("NextScene");
                SceneManager.LoadScene("Prologue7");
            }

        }

        if (textActive == true)
        {

            if (currentText == myText || i > myText.Length)
            {
                textActive = false;
            }


            Thread.Sleep(140);
            // StartCoroutine(Sleep(10f));
            if (i < myText.Length)
            {
                currentText += myText[i];
            }

            if (myText[i] != ' ')
            {
                audioSource.Play(); //오디오 재생
            }

            i++;

        }
        else
        {
            currentText = myText;

        }
        St.text = currentText;


    }




}

