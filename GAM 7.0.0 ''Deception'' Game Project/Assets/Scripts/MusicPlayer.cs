﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<FinishLineLogic>().Victory == true)
        {
            audioSource.Stop();
        }
    }
}