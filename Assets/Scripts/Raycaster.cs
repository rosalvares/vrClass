using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    float counter = 2;
    public FPSWalk fpswalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            textDebug.text = hit.transform.name;
            crosshair.transform.position = hit.point;
            crosshair.transform.forward = hit.normal;

            switch (hit.transform.gameObject.tag.ToString()){
                case "Player":
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                    counter -= Time.deltaTime;
                    if (counter < 0){
                        hit.transform.gameObject.SendMessage("ButtonAction");
                    }
                    break;
                case "Walkable":
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.blue, .5f, false, false);
                    counter -= Time.deltaTime;
                    if (counter < 0){
                        fpswalk.positionToGo = hit.transform.position;
                    }
                    break;
                case "Door":
                    crosshair.GetComponent<Image>().CrossFadeColor(Color.blue, .5f, false, false);
                    counter -= Time.deltaTime;
                    if (counter < 0){
                        if (hit.transform.gameObject.GetComponent<Door>().isOpened) {
                            hit.transform.gameObject.GetComponent<Door>().doorClosing.Play();
                        }else{
                            hit.transform.gameObject.GetComponent<Door>().doorOpening.Play();
                        }
                        hit.transform.gameObject.GetComponent<Door>().activeScript = true;
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
    }
}
