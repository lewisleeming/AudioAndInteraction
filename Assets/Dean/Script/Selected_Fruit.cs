using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Fruit : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Selected_fruit()
    {
       audioSource.Play();
    }
    public void Selected_fruit1()
    {
        audioSource.Play();
    }
}
