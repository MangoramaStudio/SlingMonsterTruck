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


    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }


}