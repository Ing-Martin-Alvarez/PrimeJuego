using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicHelperScript : MonoBehaviour
{
    public GameObject MusicHelper; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoporPlay()
    {
        if (MusicHelper.GetComponent<AudioSource>().isPlaying)
        {
            MusicHelper.GetComponent<AudioSource>().Pause();
        }
        else
        {
            MusicHelper.GetComponent<AudioSource>().Play();
        }
                
    }

    public void CambiaVolumen()
    {
        MusicHelper.GetComponent<AudioSource>().volume = GameObject.Find("VolumenMusic").GetComponent<Slider>().value;        
    }

    public void CambiaSong()
    {
        MusicHelper.GetComponent<AudioSource>().Stop();
        MusicHelper.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Centro_Pokemon");
        MusicHelper.GetComponent<AudioSource>().Play();
    }
}
