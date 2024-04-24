using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingingGlasses : MonoBehaviour
{
    //[SerializeField] private GameObject circleRecogniser;
    [SerializeField] private GameObject Liquid;

    //PappaBert
    [SerializeField] private AudioClip glass1;

    //alienistcog
    [SerializeField] private AudioClip glass2;

    //Zabuhailo
    [SerializeField] private AudioClip glass3;

    [SerializeField] private AudioSource audioSource;
    

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hands")){
            //circleRecogniser.SetActive(true);
            setSingingGlass();
        }
    }

    public void setSingingGlass(){
        Debug.Log(Liquid.transform.localScale.y);
        if(Liquid.transform.localScale.y < 0.3f){
            audioSource.clip = glass1;
        }else{
            audioSource.clip = glass2;
        }
        audioSource.Play();
    }


    // public void setSingingGlass(string recogniser){
    //     if(recogniser == "circle"){
    //         if(Liquid.transform.localScale.y < 0.3f){
    //             audioSource.clip = glass1;
    //         }else if(Liquid.transform.localScale.y < 0.6f){
    //             audioSource.clip = glass2;
    //         }else if(Liquid.transform.localScale.y < 0.10f){
    //             audioSource.clip = glass3;
    //         }
    //     }
    //     audioSource.Play();
    // }
}
