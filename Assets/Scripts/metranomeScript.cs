using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metranomeScript : MonoBehaviour
{
    private double bpm = 140;


    [SerializeField]private HingeJoint stickHinge;

    [SerializeField]private HingeJoint dialHinge;
    int buffer = 5;

    int timer = 0;

    //double sampleRate = 0;
    //double nextTick = 0;
    double nextTime = AudioSettings.dspTime + 20;

    [SerializeField] private AudioSource audioSource;

    //private AudioClip[] audioClip;


    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F; 
    bool ticked = false;

    bool onPressed = false;

    public int bpmChange = 70;

    void Start() {
        enabled = false;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;

        nextTick = startTick + (bpmChange / bpm);
    }

    void LateUpdate() {
        if (onPressed && !ticked && nextTick >= AudioSettings.dspTime ) {
            ticked = true;
            audioSource.Play();
            //BroadcastMessage( "OnTick" );
        }
    }

    void FixedUpdate() {
        if(dialHinge.angle < dialHinge.limits.min + buffer){
            bpmChange = 90;
        }else if(dialHinge.angle > dialHinge.limits.min + buffer 
        && dialHinge.angle < dialHinge.limits.max - buffer){
            bpmChange = 70;
        }else{
            bpmChange = 50;
        }

        double timePerTick = bpmChange / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( dspTime >= nextTick ) {
            ticked = false;
            nextTick += timePerTick;
        }

    }

    public void checkIfOn(){
        if(onPressed){
            offButton();
        }else{
            onButton();
        }
    }


    public void onButton(){
        onPressed = true;
        enabled = true;
    }

    public void offButton(){
        onPressed = false;
        enabled = false;
    }




}
