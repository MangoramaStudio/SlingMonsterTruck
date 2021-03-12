using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gear : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 firstTouchPos;
    private Vector3 lastTouchPos;

    public float angle;

    public GameObject gear;

    private float gearTime = 0.5f;
    public enum GearType {R,N,D};

    public GearType gearType;

    public GameObject fireEngineButton;

    public Material readyMaterial, firstMaterial;

    void Start()
    {
        gearType = GearType.N;
        firstMaterial = fireEngineButton.transform.GetComponent<MeshRenderer>().material;

        //gear.transform.GetComponent<Material>().SetVector("_EmissionColor", new Vector4(0.8196f, 0.783f, 0) * -4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        Debug.Log("onMouseDown");
        firstTouchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        lastTouchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        FingerMovesAngle();
    }

    void FingerMovesAngle()
    {
        //Debug.Log("last y : " + lastTouchPos.y + "first y : " + firstTouchPos.y);
        //Debug.Log("last x: " + lastTouchPos.x + "first x : " + firstTouchPos.x);
        if (Mathf.Abs(lastTouchPos.y - firstTouchPos.y) < 1 )//check if its just a click
        {
            angle = Mathf.Atan2(lastTouchPos.y - firstTouchPos.y, lastTouchPos.x - firstTouchPos.x) * 180 / Mathf.PI;
            MovePieces();
            Debug.Log("angle : " + angle);
        }
    }

    void MovePieces()
    {
        if (angle > -45 && 45 >= angle)//Right Swipe
        {
            
        }
        else if (angle <= -45 && angle > -135)//Down Swipe
        {
            Debug.Log("DownSwipe!");

            Destroy(gear.GetComponent<Animator>());

            if (gearType == GearType.D)
            {
                gear.transform.DORotate(new Vector3(-20, 0, 0), gearTime, RotateMode.LocalAxisAdd);
                gearType = GearType.N;
                fireEngineButton.GetComponent<MeshRenderer>().material = firstMaterial;
            }
            else if (gearType == GearType.N)
            {
                gear.transform.DORotate(new Vector3(-20, 0, 0), gearTime, RotateMode.LocalAxisAdd);
                gearType = GearType.R;
            }
            

        }
        else if (angle <= -135 || angle > 135 )//Left Swipe
        {
            
        }

        else if (angle <= 135 && angle > 45)//Up Swipe
        {
            Debug.Log("upSwipe!");
            //gear.transform.DORotate(new Vector3(20, 0, 0), gearTime, RotateMode.LocalAxisAdd);
            Destroy(gear.GetComponent<Animator>());
            
            if (gearType == GearType.R)
            {
                gear.transform.DORotate(new Vector3(20, 0, 0), gearTime, RotateMode.LocalAxisAdd);
                gearType = GearType.N;
            }
            else if (gearType == GearType.N)
            {
                gear.transform.DORotate(new Vector3(20, 0, 0), gearTime, RotateMode.LocalAxisAdd);
                gearType = GearType.D;
                fireEngineButton.GetComponent<MeshRenderer>().material = readyMaterial;
            }



        }

    }

    



}
