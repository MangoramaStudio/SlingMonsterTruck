using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Car : MonoBehaviour
{
    private Rigidbody _rb;
    //public float ExplosionRadius;
    //public LayerMask ShardLayers;
    //public float ExplosionForce;

    //private GameManager gameManager;

    public GameObject particle;

    private Canvas canvas;

    public Joystick joystick;

    private float speed = 10;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        if (particle != null)
        {
            particle.SetActive(false);
        }

        canvas = FindObjectOfType<Canvas>();
    }

    public void Push(Vector3 force)
    {
        _rb.isKinematic = false;
        _rb.AddForce(_rb.mass * force, ForceMode.Impulse);
    }


    void FixedUpdate()
    {
        //Debug.Log("Car velocity : " + transform.GetComponent<Rigidbody>().velocity);
        //Debug.Log("joystick vertical : " + joystick.Horizontal);
        transform.position += new Vector3(joystick.Horizontal, 0) * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }


}