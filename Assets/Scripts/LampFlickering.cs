using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFlickering : MonoBehaviour
{
    public Light light;
    public bool flikering=false;
    public int flikRange = 100;
    // Start is called before the first frame update
    void Start()
    {
        
        if (Random.Range(0, flikRange) < 50)
        {
            flikering = true;
            
        }

        TurnLightOn();
    }

   void TurnLightOn()
    {
        light.intensity = 2.8f;
        if (flikering)
        {
            Invoke("TurnLightOff", Random.Range(0, 0.3f));
        }
    }

    void TurnLightOff()
    {
        light.intensity = 0;

        if (flikering)
        {
            Invoke("TurnLightOn", Random.Range(0.5f, 5f));
        }
    }
}
