using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class PathFollowObject : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isEnterPath;

    private GameObject car;
    private bool isTakeForce;

    private Vector3 enterVelocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Car>() != null)
        {
            car = other.transform.gameObject;
            //Debug.Log(car.gameObject.name);
            if (isEnterPath)
            {
                //Debug.Log("triggered");
                other.transform.GetComponent<PathFollower>().enabled = true;
                FindObjectOfType<GameManager>().pathEnterForce = car.transform.GetComponent<Rigidbody>().velocity;
            }
            else
            {
                if (!isTakeForce)
                {
                    isTakeForce = true;
                    other.transform.GetComponent<PathFollower>().enabled = false;
                    other.transform.GetComponent<Rigidbody>().isKinematic = true;
                    //other.transform.GetComponent<Rigidbody>().mass = 0.5f;
                    //other.transform.rotation = Quaternion.Euler(0, 0, 0);
                    Invoke("GiveForce", 0.001f);
                }
                    
            }
            
        }
        
    }

    private void GiveForce()
    {
        StartCoroutine(GiveForceIE());
    }

    private IEnumerator GiveForceIE()
    {
        //Debug.Log("enter");
        car.transform.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForEndOfFrame();
        //car.transform.GetComponent<Rigidbody>().AddForce(FindObjectOfType<GameManager>().pathEnterForce * 1.5f , ForceMode.Impulse);
        car.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0,1,1) * 100 , ForceMode.Impulse);
    }
}
