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

    private float speed = 20;

    private float rotationValue;

    private Quaternion targetRot;

    private float firstZRot;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        if (particle != null)
        {
            particle.SetActive(false);
        }

        canvas = FindObjectOfType<Canvas>();

        firstZRot = transform.rotation.eulerAngles.z;
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

        if (joystick.gameObject.activeInHierarchy && joystick.Horizontal != 0)
        {
            rotationValue = firstZRot + (joystick.Horizontal * 20);

            rotationValue = Mathf.Clamp(rotationValue, -30, 30);

            //Debug.Log("rotation : " + rotationValue);

            targetRot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, - rotationValue);

            transform.rotation = targetRot;

            transform.position += new Vector3(joystick.Horizontal, 0) * Time.deltaTime * speed;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }


}