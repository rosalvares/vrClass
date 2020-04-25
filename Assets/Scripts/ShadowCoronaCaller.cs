using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCoronaCaller : MonoBehaviour
{
    public GameObject ShadowCorona;
    public bool callShadowCorona = false;
    private AudioSource audioToPlay;

    // Update is called once per frame
    void Update(){
        Debug.Log(callShadowCorona);
        if (callShadowCorona){
            ShadowCorona.GetComponent<ShadowMove>().canMove = true;
            switch (Random.Range(0, 3)){
                case 0:
                    audioToPlay = ShadowCorona.GetComponent<ShadowMove>().espirro;
                    break;
                case 1:
                    audioToPlay = ShadowCorona.GetComponent<ShadowMove>().tosse;
                    break;
                case 2:
                    audioToPlay = ShadowCorona.GetComponent<ShadowMove>().tosseEspirro;
                    break;
            }
            audioToPlay.Play();
            Destroy(this.gameObject);
        }
    }
}
