using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject road1, road2;

    public Vector3 pathEnterForce;

    public float distanceMultiplier;

    void Start()
    {
        //Application.targetFrameRate = 60;
        RestartSceneManage();

    }

    public void RestartSceneManage()
    {
        if (PlayerPrefs.GetInt("roadIndex") == 0)
        {
            road1.SetActive(true);
            road2.SetActive(false);
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            road1.SetActive(false);
            road2.SetActive(true);
        }

        FBManager.Instance.SendEventLevelStarted(PlayerPrefs.GetInt("levelIndex"));
    }

    public void RestartCommand()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
