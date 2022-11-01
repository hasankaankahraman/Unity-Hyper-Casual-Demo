using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UIManager uimanager;
    private Rigidbody rb;
    private Touch touch;

    [Range(20, 40)]
    public int playerspeed;
    public int camandBallspeed;


    public GameObject cam;
    public GameObject FVector;
    public GameObject BVector;

    private bool camandballstop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Variables.firsttouch == 1 && camandballstop == false)
        {
            transform.position         += new Vector3(0, 0, camandBallspeed * Time.deltaTime);  // Topun ilerledi.
            cam.transform.position     += new Vector3(0, 0, camandBallspeed * Time.deltaTime); // Kamera ilerledi.
            FVector.transform.position += new Vector3(0, 0, camandBallspeed * Time.deltaTime); // Topun ileri çýkmama vektörü ilerledi.
            BVector.transform.position += new Vector3(0, 0, camandBallspeed * Time.deltaTime); // Topun geri çýkmama vektörü ilerledi.
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) 
            {
                Variables.firsttouch = 1;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * playerspeed * Time.deltaTime,
                                          touch.deltaPosition.y,
                                          touch.deltaPosition.y * playerspeed * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended) 
            {
                rb.velocity = Vector3.zero;
                //rb.velocity = new Vector3(0, 0, 0);
            }
        }

    }

    public GameObject[] bombitems;

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("pain"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in bombitems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(TimeScaleControl());

            
        }

    }
    public IEnumerator TimeScaleControl()
    {
        camandballstop = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        rb.velocity = Vector3.zero;
        uimanager.RestartButtonActive();
        
    }
}
