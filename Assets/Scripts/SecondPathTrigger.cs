using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;

public class SecondPathTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCar;
    //public PathFollower mainCarFollower;
    public PathCreator path2;
    private bool isEnter;


    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Car>() != null && !isEnter)
        {
            isEnter = true;
            StartCoroutine(PathControlIE());
        }
    }

    private IEnumerator PathControlIE()
    {
        Destroy(mainCar.GetComponent<PathFollower>());
        yield return new WaitForEndOfFrame();
        //yield return new WaitForSeconds(2);
        mainCar.AddComponent<PathFollower>();
        yield return new WaitForEndOfFrame();
        mainCar.GetComponent<PathFollower>().endOfPathInstruction = EndOfPathInstruction.Stop;
        //yield return new WaitForEndOfFrame();
        mainCar.GetComponent<PathFollower>().pathCreator = path2;
        //yield return new WaitForEndOfFrame();
        mainCar.GetComponent<PathFollower>().speed = 270;
        //yield return new WaitForEndOfFrame();


    }
}
