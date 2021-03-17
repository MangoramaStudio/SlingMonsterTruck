using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Facebook.Unity;

public class RoadFinish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;

    public bool isTriggerforJoystick;

    public GameObject levelEndPanel;

    public GameObject[] particles;

    public bool isWinCollider;

    private bool isInsideOnce;

    int levelIndex;

    private void Start()
    {
        
    }

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
        if (collision.transform.GetComponent<Car>() != null && !isInsideOnce)
        {
            isInsideOnce = true;
             
            levelIndex = PlayerPrefs.GetInt("levelIndex");
            levelIndex++;
            PlayerPrefs.SetInt("levelIndex", levelIndex);

            //place for finish win
            if (isWinCollider)
            {
                
                levelEndPanel.transform.Find("StickForWinOrFail/WinImage").gameObject.SetActive(true);
                collision.transform.GetComponent<Rigidbody>().isKinematic = true;
                collision.transform.rotation = Quaternion.Euler(0, 0, 0);
                collision.transform.DOMoveZ(collision.transform.position.z + 20, 1);

                //Debug.Log("roadIndex : " + PlayerPrefs.GetInt("roadIndex"));
                if (PlayerPrefs.GetInt("roadIndex") == 0)
                {
                    PlayerPrefs.SetInt("roadIndex", 1);
                }else
                {
                    PlayerPrefs.SetInt("roadIndex", 0);
                }

                FBManager.Instance.SendEventLevelCompleted(levelIndex);
            }
            else
            {
                levelEndPanel.transform.Find("StickForWinOrFail/FailImage").gameObject.SetActive(true);

                FBManager.Instance.SendEventLevelFailed(levelIndex);
            }
            Invoke("BringPanel", 2);
        }
    }

    private void BringPanel()
    {
        levelEndPanel.SetActive(true);
    }
}
