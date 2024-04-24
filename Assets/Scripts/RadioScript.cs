using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{

    [SerializeField]private AudioClip[] clips;
    [SerializeField] private AudioSource audioSource;

    private int count = 0;

    void Start() {
        //audioSource.GetComponent<AudioSource>();
    }

    public void playButtonPressed(){
        audioSource.clip = clips[count];
        audioSource.Play();
    }

    public void nextButtonPressed(){
        if(count < clips.Length)
        {
        count++;
        audioSource.clip = clips[count];
        audioSource.Play();
        }
        else
        {
            count = 0;
            audioSource.clip = clips[count];
            audioSource.Play();
            count++;
        }
    }

    public void stopButton(){
        audioSource.Stop();
    }
}
