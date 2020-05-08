using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource doorClosing;
    public AudioSource doorOpening;
    public Transform doorMesh;
    public bool isOpened;
    public int speedMove = 1;
    public void ButtonAction()
    {
        if (isOpened){
            doorClosing.Play();
            StartCoroutine(Fecha());
        }else{
            doorOpening.Play();
            StartCoroutine(Abre());
        }
        
    }

    public IEnumerator Abre()
    {
        float ang = 0; //posicao da porta inicial
        while (ang > -148) //enquanto o angulo for menor q -148
        {
            ang = Mathf.Lerp(ang, -150, Time.deltaTime * speedMove); // interpola para -150
            doorMesh.transform.rotation = Quaternion.Euler(0, ang, 0); //aplica a rotaçao 

            yield return new WaitForEndOfFrame(); //espera o loop até o fim do update

        }
        isOpened = true; // seta a booleanada porta como aberta
    }
    //mesma coisa só q ao contrario
    public IEnumerator Fecha()
    {
        float ang = -150;
        while (ang < 0)
        {
            ang = Mathf.Lerp(ang, 1, Time.deltaTime * speedMove);
            doorMesh.transform.rotation = Quaternion.Euler(0, ang, 0);

            yield return new WaitForEndOfFrame();

        }

        isOpened = false;

    }

}
