using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
	public float ExplosionRadius;
	public LayerMask ShardLayers;
	public float ExplosionForce;

    //private GameManager gameManager;

    private bool isCollision;

    public bool isColor;
    public GameObject particle;

    private int randomValue;
    private Quaternion quaternion;

    private bool throwBool;

    public GameObject textDecrease;


    private Canvas canvas;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        //gameManager = FindObjectOfType<GameManager>();

        //if (!isColor)
        //{
        //randomValue = Random.Range(0, transform.childCount);
        //    transform.GetChild(randomValue).gameObject.SetActive(true);
        //}
        if (particle != null)
        {
            particle.SetActive(false);
        }

        //quaternion = transform.GetChild(randomValue).rotation;

        canvas = FindObjectOfType<Canvas>();
        //throwBool = 
    }

    public void Push(Vector3 force) {
		_rb.isKinematic = false;
		_rb.AddForce(_rb.mass * force, ForceMode.Impulse);
	}

    //void Explode(Vector3 position)
    //{
    //	foreach (var shard in Physics.OverlapSphere(position, ExplosionRadius, ShardLayers))
    //	{
    //		var rb = shard.GetComponent<Rigidbody>();

    //		rb.isKinematic = false;
    //		rb.AddExplosionForce(ExplosionForce, position, ExplosionRadius);

    //		//shard.gameObject.AddComponent<DestroyIn>().Time = 3.0f;
    //	}
    //}


    void Update()
    {
        //if (gameManager.currentBall == transform.gameObject)
        //{
        //    transform.position = gameManager.currentSwipe.transform.parent.Find("Dummy005").position;
        //}
        //if (gameManager.currentSwipe != null)
        //{
        //    if (gameManager.currentSwipe.isThrow && !isCollision)
        //    {
        //        //transform.GetComponent<Rigidbody>().AddTorque(Vector3.forward);


        //        quaternion.eulerAngles += Vector3.up * Time.deltaTime * 300f;

        //        transform.GetChild(randomValue).rotation = quaternion;
        //    }
        //}
        

    }


    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.GetComponent<Collider>() != null)
        //{
        //    Vector3 collPoint = collision.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        //    if (collision.transform.GetComponent<Fracture>() != null)
        //    {

        //        Debug.Log(collision.gameObject.name);
        //        //Explode(collision.transform.position);

        //        collision.transform.GetComponent<Fracture>().Prefab.GetComponent<MeshRenderer>().material = collision.transform.GetComponent<MeshRenderer>().materials[0];
        //        transform.GetComponent<Breaker>().Break(collision.transform.GetComponent<Fracture>(), collPoint);

        //        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        //        //MakeText(collPoint);

        //        //Destroy(transform.gameObject);
        //        //transform.position = collision.transform.position;
        //    }

        //    isCollision = true;
        //    transform.GetComponent<Rigidbody>().freezeRotation = true;

        //    if (collision.gameObject.tag == "color")
        //    {
        //        Debug.Log("Ball on Target !! ");
        //        particle.SetActive(true);
        //        particle.GetComponent<ParticleSystem>().Play();
        //        Destroy(transform.gameObject, 0.025f);
        //        MakeText(collPoint,false);

        //    }

        //    if (collision.gameObject.tag == "partObject")
        //    {
        //        MakeText(collPoint,false);
        //    }
        //}
        
	}

    public void MakeText(Vector3 insPos, bool isHuman)
    {
        //GameObject text = Instantiate(textDecrease, insPos, Quaternion.identity);
        //if (SceneManager.GetActiveScene().name == "CarScene" || SceneManager.GetActiveScene().name == "SculptureScene")
        //{
        //    text.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //}

        //float randomValue = Random.Range(-1500, -2000);

        //if (isHuman)
        //{
        //    text.transform.GetChild(0).GetComponent<TextMeshPro>().text = "medical expenses " + randomValue.ToString() + " $";

        //}
        //else
        //{
        //    text.transform.GetChild(0).GetComponent<TextMeshPro>().text = randomValue.ToString() + " $";

        //}


        //LeanTween.moveY(text, 100, 10);


        //canvas.transform.Find("DecreaseSlider").GetComponent<Slider>().value += randomValue;

        //gameManager.CheckIsWin();
    }


}