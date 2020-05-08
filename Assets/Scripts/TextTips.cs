using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTips : MonoBehaviour
{
    public TextMesh textTip;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter < 0)
        {
            textTip.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
