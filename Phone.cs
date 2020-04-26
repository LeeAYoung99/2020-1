using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject home;
    public GameObject realgallery;
    public GameObject realmessage;
    public GameObject password;
    public GameObject realpic;

    public Text passwordtext;

    static int state;
    static bool locked;
    /*
     state 1: 홈 화면
     state 2: 갤러리 화면
     state 3: 메시지 화면
     state 4: 홈 화면+비밀번호 입력창
     state 5: 갤러리 사진 확대
         */

    void Awake()
    {
        state = 1;
        locked = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1) //홈 화면일때
        {
            // 화면에 보이게 하기
            if (home.activeSelf == false)
            {
                home.gameObject.SetActive(true);
            }
            if (realgallery.activeSelf == true)
            {
                realgallery.gameObject.SetActive(false);
            }
            if (realmessage.activeSelf == true)
            {
                realmessage.gameObject.SetActive(false);
            }
            if (password.activeSelf == true)
            {
                password.gameObject.SetActive(false);
            }
            if (realpic.activeSelf == true)
            {
                realpic.gameObject.SetActive(false);
            }



        }
        else if (state == 2) // 갤러리 화면일때
        {
            
            // 화면에 보이게 하기
            if (home.activeSelf == true)
            {
                home.gameObject.SetActive(false);
            }
            if (realgallery.activeSelf == false)
            {
                realgallery.gameObject.SetActive(true);
            }
            if (realmessage.activeSelf == true)
            {
                realmessage.gameObject.SetActive(false);
            }
            if (password.activeSelf == true)
            {
                password.gameObject.SetActive(false);
            }
            if (realpic.activeSelf == true)
            {
                realpic.gameObject.SetActive(false);
            }

        }
        else if (state == 3) //메시지 화면일때
        {
            // 화면에 보이게 하기
            if (home.activeSelf == true)
            {
                home.gameObject.SetActive(false);
            }
            if (realgallery.activeSelf == true)
            {
                realgallery.gameObject.SetActive(false);
            }
            if (realmessage.activeSelf == false)
            {
                realmessage.gameObject.SetActive(true);
            }
            if (password.activeSelf == true)
            {
                password.gameObject.SetActive(false);
            }
            if (realpic.activeSelf == true)
            {
                realpic.gameObject.SetActive(false);
            }
        }
        else if (state == 4)
        {
            // 화면에 보이게 하기
            if (home.activeSelf == false)
            {
                home.gameObject.SetActive(true);
            }
            if (realgallery.activeSelf == true)
            {
                realgallery.gameObject.SetActive(false);
            }
            if (realmessage.activeSelf == true)
            {
                realmessage.gameObject.SetActive(false);
            }
            if (password.activeSelf == false)
            {
                password.gameObject.SetActive(true);
            }
            if (realpic.activeSelf == true)
            {
                realpic.gameObject.SetActive(false);
            }

        }
        else if (state == 5) // 갤러리 화면일때+확대
        {

            // 화면에 보이게 하기
            if (home.activeSelf == true)
            {
                home.gameObject.SetActive(false);
            }
            if (realgallery.activeSelf == false)
            {
                realgallery.gameObject.SetActive(true);
            }
            if (realmessage.activeSelf == true)
            {
                realmessage.gameObject.SetActive(false);
            }
            if (password.activeSelf == true)
            {
                password.gameObject.SetActive(false);
            }
            if (realpic.activeSelf == false)
            {
                realpic.gameObject.SetActive(true);
            }

        }



    }

    public void GalleryIcon()
    {

        
        if (state == 1) //홈 화면일때만 발동
        {
             state = 2;
        }
    }
    public void MessageIcon()
    {
        
        if (state == 1) //홈 화면일때만 발동
        {
            if (locked) // 잠금을 해제하지 못했다면
            {
                state = 4;
            }
            else if (!locked) //잠금을 해제했다면
            {
                state = 3;
            }
       }
    }

    public void OKbutton()
    {
        if(passwordtext.text.ToString()=="KLIL"||passwordtext.text.ToString()=="klil")
        {
            locked = false;
            state = 3;
        }
        else
        {
            state = 1;
        }
    }

    public void GalleryOpen()
    {
        state = 5;
    }

    public void BackButton()
    {
        if (state == 2)
        {
            state = 1;
        }
        else if (state == 3)
        {
            state = 1;
        }
        else if (state == 5)
        {
            state = 2;
        }
    }

}
