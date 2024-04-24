using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{            
    
    
    AudioSource source;
    Collider soundTrigger;
    // Start is called before the first frame update




            void Awake()
            {
                source = GetComponent<AudioSource>();
                soundTrigger = GetComponent<Collider>();
            }

            void OnTriggerEnter(Collider collider)
            {
                if(!collider.CompareTag("CounterTops"))
                {
                source.Play();
                }

            }
        }
    


