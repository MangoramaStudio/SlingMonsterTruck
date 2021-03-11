using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thirdPersonVCam;
    public GameObject insideVCam;
    public Gear gearObject;
    public GameObject swipeObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        Debug.Log("FireButton");

        if (gearObject.gearType == Gear.GearType.D)
        {
            thirdPersonVCam.SetActive(true);
            insideVCam.SetActive(false);
            Invoke("SlingOpen", 0.5f);
        }
    }

    private void SlingOpen()
    {
        swipeObject.GetComponent<Swipe>().enabled = true;
    }
}
