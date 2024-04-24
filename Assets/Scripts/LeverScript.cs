using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverScript : MonoBehaviour
{
    //angle threshold to trigger if we reached limit
    public float angleBetweenThreshold = 1f;

    //Event called on min reache
    private HingeJoint hinge;
    public ParticleSystem water;

    [SerializeField] GameObject waterArea;

    //[SerializeField] private GameObject waterArea;
    [SerializeField] private int buffer;
    [SerializeField] private AudioSource waterAudio;



    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        waterArea.SetActive(false);
    }

    void Update()
    {


        //Reached Min
        if(hinge.angle > hinge.limits.min + buffer)
        {
            if(!water.isPlaying){
                water.Play();
                waterAudio.Play();
            }
            waterArea.SetActive(true);
        }
        //No Limit reached
        else
        {
            if(water.isPlaying){
                water.Stop();
                waterAudio.Stop();
            }
            waterArea.SetActive(false);
        }
    }
}