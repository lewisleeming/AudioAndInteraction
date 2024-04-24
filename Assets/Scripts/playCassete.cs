using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;

public class playCassete : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipaudio;

    //public createCassete cassete;

    public void playNewCassete() {
        audioSource = gameObject.GetComponent<AudioSource>();
        //cassete = GameObject.Find("soundbutton").GetComponent<createCassete>();
        // clipaudio = cassete.audioClip;
        // audioSource.clip = clipaudio;
        audioSource.clip = clipaudio;
        audioSource.Play();
    }

    public void stopCassete(){
        audioSource.Stop();
    }
    
}
