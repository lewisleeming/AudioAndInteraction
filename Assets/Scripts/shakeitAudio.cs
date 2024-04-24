using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeitAudio : MonoBehaviour
{
    public Rigidbody rigid;
    private Vector3 storedVelocity;

    public Transform SaltShaker;
    private Vector3 SaltShakerVector;

    AudioSource audioSource;

    public AudioClip shakeAudio;

    public float checkRate = 0.35f;
    public float lowVolume = 0.1f;
    public float highVolume = 0.3f;

    private float speed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // audiosource on object
        SaltShakerVector = SaltShaker.position; // store intial cube position
        storedVelocity = rigid.velocity; // store intial cube velocity
        InvokeRepeating("ShakeIt", 0f, checkRate); //  how often to run shake it
    }

    private void Update()
    {
        speed = storedVelocity.magnitude; // speed at which the cube is moved
        
    }

    void ShakeIt()
    {
        if (rigid.velocity != Vector3.zero) 
        {
            if (SaltShakerVector != SaltShaker.position && storedVelocity != rigid.velocity) // if its position is not equal to previous and velocity is not equal to previous
            {
                SaltShakerVector = SaltShaker.position; //update cube position
                storedVelocity = rigid.velocity; //  update velocity

                if (speed > 0.3f) // has to have a magnitude faster than float
                {
                    if (speed < 0.7f) // if speed it slower than this float low volume
                    {
                        audioSource.volume = highVolume;
                        audioSource.PlayOneShot(shakeAudio);
                    }
                    else if (speed >= 0.7f) //  if speed is faster than this higher volume
                    {
                        audioSource.volume = highVolume;
                        audioSource.PlayOneShot(shakeAudio);
                    }

                }

            }
        }

    }
}
