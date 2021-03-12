using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFinish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;

    public bool isTriggerforJoystick;

    public GameObject winPanel, losePanel;

    public GameObject[] particles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Car>() != null && isTriggerforJoystick)
        {
            joystick.SetActive(true);

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Car>() != null)
        {
            //place for finish win
            winPanel.SetActive(true);
        }
    }
}
