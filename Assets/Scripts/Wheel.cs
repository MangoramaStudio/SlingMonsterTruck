using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 rotateVector;

    private float speed = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateVector += new Vector3(1, 0, 0);
        transform.rotation = Quaternion.Euler(rotateVector * Time.deltaTime * speed); 
    }
}
