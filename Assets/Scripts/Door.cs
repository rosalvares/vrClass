using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource doorClosing;
    public AudioSource doorOpening;
    public Transform doorMesh;
    public bool isOpened;
    public bool activeScript = false;

    void Update(){        
        if (activeScript){
            if (isOpened){
                StartCoroutine(Fecha());
            }else{
                StartCoroutine(Abre());
            }
        }
    }

   
    public IEnumerator Abre(){
        while (doorMesh.transform.rotation.eulerAngles.y != -150){
            doorMesh.transform.rotation = Quaternion.Lerp(doorMesh.transform.rotation, Quaternion.Euler(0,-150,0), Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator Fecha(){
        while (doorMesh.transform.rotation.eulerAngles.y != 0){
            doorMesh.transform.rotation = Quaternion.Lerp(doorMesh.transform.rotation, Quaternion.identity, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
