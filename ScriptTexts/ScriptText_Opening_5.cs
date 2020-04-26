using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;


public class ScriptText_Opening_5 : MonoBehaviour
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
        myText = "내일 딸래미 학예회가 있는 날이라\n자네에게 일 좀 부탁하겠네.";
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
                SceneManager.LoadScene("Prologue6");
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

