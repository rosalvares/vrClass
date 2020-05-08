using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    float counter = 2;
    public FPSWalk fpswalk;
    public bool hasMaskKey = false;
    public float distanceToLook = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceToLook))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            textDebug.text = hit.transform.name;
            crosshair.transform.position = hit.point;
            crosshair.transform.forward = transform.forward;

            Debug.Log(hit.transform.gameObject.tag.ToString());
            switch (hit.transform.gameObject.tag.ToString()) {
                case "Interactable":
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                    counter -= Time.deltaTime;
                    if (counter < 0) {
                        hit.transform.gameObject.SendMessage("ButtonAction");
                        counter = 3;
                    }
                    break;
                case "InteractableMask":
                    if (hasMaskKey) { 
                        crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                        counter -= Time.deltaTime;
                        if (counter < 0)
                        {
                            fpswalk.hasMask = true;
                            distanceToLook = 12;
                            fpswalk.ChangeDeathSound();
                            hit.transform.gameObject.SendMessage("ButtonAction");
                            counter = 3;
                        }
                    }
                    break;
                case "Key":
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.blue, .5f, false, false);
                    counter -= Time.deltaTime;
                    if (counter < 0)
                    {
                        hasMaskKey = true;
                        Destroy(hit.transform.gameObject);                        
                        fpswalk.positionToGo = new Vector3(-22.21f, 0.01f,1.02f);
                    }
                    break;                
                case "Walkable":
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.blue, .5f, false, false);
                    counter -= Time.deltaTime;
                    if (counter < 0){
                        fpswalk.positionToGo = hit.transform.position;
                    }
                    break;
                case "ShadowCoronaTrigger":
                    try{
                        hit.transform.gameObject.GetComponent<ShadowCoronaCaller>().callShadowCorona = true;
                    }catch
                    {
                        Debug.Log("Erro");
                    }
                    break;
                default:
                    counter = 3;
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.red, .5f, false, false);
                    break;
            }
        }
        else
        {
            //se nao da raycast o crosshair some
            crosshair.GetComponent<Image>().CrossFadeColor(Color.black, .0f, false, false);
        }
    }
}
