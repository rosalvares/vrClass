using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSWalk : MonoBehaviour
{

    public CharacterController character;
    public Vector3 positionToGo;
    public AudioSource stepSound;
    bool safe = false;
    float counttodie = 5;
    private AudioSource warning;
    public AudioSource warningRegular;
    public AudioSource warningLong;
    public TextMesh textDeath;
    public bool hasMask = false;

    // Start is called before the first frame update
    void Start()
    {
        positionToGo = transform.position;
        warning = warningRegular;
        warning.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 diftowalk = positionToGo - transform.position;

        character.SimpleMove(diftowalk.normalized);

        if (character.velocity.magnitude > 0.4 && !stepSound.isPlaying){
            stepSound.volume = Random.Range(0.75f, 1);
            stepSound.pitch =  Random.Range(0.75f, 1);
            stepSound.Play();
        }

        if (!safe)
        {
            counttodie -= Time.deltaTime;
            warning.volume += Time.deltaTime / 5;
            if (counttodie < 0)
            {
                //SceneManager.LoadScene("Menu");
                //Game Over
                enabled = false;
            }
        }
        else
        {
            counttodie = 5;
            if (hasMask)
            {
                counttodie = 10;
            }
            warning.volume = Mathf.Lerp(warning.volume, 0, Time.deltaTime);
        }
        textDeath.text = "Tempo para infecção: " + Mathf.RoundToInt(counttodie).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Walkable"))
        {
            safe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Walkable"))
        {
            safe = false;
        }
    }

    public void ChangeDeathSound()
    {
        warning = warningLong;
    }
}
