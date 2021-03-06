﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-9.53f, 2.28f, -6f);
    private Vector3 pos2 = new Vector3(-9.53f, 2.28f, -4.25f);
    public float speed = 1.0f;
    public bool canMove = false;

    public AudioSource tosse;
    public AudioSource tosseEspirro;
    public AudioSource espirro;
    private AudioSource audioToPlay;

    void Start(){        
        switch (Random.Range(0, 3)){
            case 0:
                audioToPlay = tosse;
                break;
            case 1:
                audioToPlay = tosseEspirro;
                break;
            case 2:
                audioToPlay = espirro;
                break;
        }
        audioToPlay.Play();
        StartCoroutine(Anda());
        Destroy(this, 5f);        
    }

    public IEnumerator Anda()
    {
        while (transform.position.z < -4.6f)
        {
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
            yield return new WaitForEndOfFrame();
        }
    }
}
