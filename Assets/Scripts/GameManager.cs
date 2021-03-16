using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject road1, road2;

    public Vector3 pathEnterForce;

    void Start()
    {
        //Application.targetFrameRate = 60;


    }

    public void RestartScene()
    {
        if (PlayerPrefs.GetInt("roadIndex") == 0)
        {
            road1.SetActive(true);
            road2.SetActive(false);
            PlayerPrefs.SetInt("roadIndex", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            road1.SetActive(false);
            road2.SetActive(true);
            PlayerPrefs.SetInt("roadIndex", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
