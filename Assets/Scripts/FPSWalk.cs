using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWalk : MonoBehaviour
{

    public CharacterController character;
    public Vector3 positionToGo;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        positionToGo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diftowalk = positionToGo - transform.position;

        character.SimpleMove(diftowalk.normalized);

        if (character.velocity.magnitude > 0.4 && !audioSource.isPlaying){
            audioSource.volume = Random.Range(0.75f, 1);
            audioSource.pitch =  Random.Range(0.75f, 1);
            audioSource.Play();
        }
       
    }
}
