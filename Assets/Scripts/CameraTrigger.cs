using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enterVCam, thirdPersonCam;

    public bool isEnterPath;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Car>() != null)
        {
            if (isEnterPath)
            {
                enterVCam.SetActive(true);
                thirdPersonCam.SetActive(false);
            }
            else
            {
                thirdPersonCam.SetActive(true);
            }

        }
    }
}
