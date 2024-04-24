using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill_up_script : MonoBehaviour
{

    private float currentTime;
    private bool startTimer;

    [SerializeField] private GameObject Liquid;

    [SerializeField] private int adjuster;

    //[SerializeField] private GameObject circleRecogniser;

    [SerializeField] private GameObject waterRipples;
    [SerializeField] private ParticleSystem FullWaterEffect;

    // Start is called before the first frame update
    void Start()
    {
        //circleRecogniser.SetActive(false);
        //Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log("triggered");
        if(other.tag == "Cups"){
            waterRipples.SetActive(false);


            //Debug.Log("filling cup");
            //currentTime += Time.deltaTime;
            if(Liquid.transform.localScale.y < 0.8f){
                Liquid.transform.localScale += new Vector3(0f, 0.01f, 0f);
                Liquid.transform.localPosition += new Vector3(0f,0.01f,0f);
            }
        }
        // if(other.tag == "recogniser"){
        //     Debug.Log("Start recogniser");
        //     circleRecogniser.SetActive(true);
        // }
    }

    private void OnTriggerExit(Collider other) {
        //Debug.Log("exittt");
        waterRipples.SetActive(true);
        FullWaterEffect.Stop();
        FullWaterEffect.Play();
    }

    // private void StartRecogniser(){
    //     circleRecogniser.SetActive(true);
    // }
}
