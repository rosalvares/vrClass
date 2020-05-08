using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public AudioSource doorOpening;
    public Transform doorMesh;
    public Rigidbody rdb;
    public Vector3 secondPosition;
    public GameObject mask;

    public void ButtonAction()
    {        
        doorOpening.Play();
        StartCoroutine(Abre());        
    }

    public IEnumerator Abre()
    {
        while (transform.position.x < secondPosition.x)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            Destroy(this, 0.9f);
            Destroy(mask, 0.9f);
            yield return new WaitForEndOfFrame(); //espera o loop até o fim do update
        }
        
    }
}
