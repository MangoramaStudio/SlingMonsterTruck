using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedPlace : MonoBehaviour
{
    public GameObject losePanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Car>() != null)
        {
            losePanel.SetActive(true);
        }
    }
}
