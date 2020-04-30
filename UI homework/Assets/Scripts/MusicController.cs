using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Slider musicTime;
    public AudioSource kerningCityAudio;

    bool _isPlaying;
    

    // Start is called before the first frame update
    void Start()
    {
        kerningCityAudio.time = musicTime.value * kerningCityAudio.clip.length;
        _isPlaying = PlayButton.isPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayButton.isPlaying!=_isPlaying&&PlayButton.isPlaying==true)
        {
            kerningCityAudio.Play();
            
        }
        else if(_isPlaying==true)
        {
            musicTime.value = kerningCityAudio.time / kerningCityAudio.clip.length;
        }
        else
        {
            kerningCityAudio.Stop();
        }

        

        _isPlaying = PlayButton.isPlaying;
         
        
    }

    public void SoundSlider()
    {
        kerningCityAudio.time = musicTime.value * kerningCityAudio.clip.length;

    }

}
