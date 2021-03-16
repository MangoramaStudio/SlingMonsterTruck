using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadFinish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;

    public bool isTriggerforJoystick;

    public GameObject levelEndPanel;

    public GameObject[] particles;

    public bool isWinCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Car>() != null && isTriggerforJoystick)
        {
            joystick.SetActive(true);

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].GetComponent<ParticleSystem>().Stop();
            }
            other.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Car>() != null)
        {
            //place for finish win
            if (isWinCollider)
            {
                levelEndPanel.transform.Find("StickForWinOrFail/Text").GetComponent<Text>().text = "Win";
            }
            else
            {
                levelEndPanel.transform.Find("StickForWinOrFail/Text").GetComponent<Text>().text = "Fail";
            }
            levelEndPanel.SetActive(true);

        }
    }
}
