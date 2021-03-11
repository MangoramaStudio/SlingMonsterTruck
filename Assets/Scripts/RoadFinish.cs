using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFinish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Car>() != null)
        {
            joystick.SetActive(true);
        }
    }
}
