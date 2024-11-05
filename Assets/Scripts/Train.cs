using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private float speed;

    Rigidbody rb;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();


        if (speed != 0f)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Hit();
            Destroy(gameObject);
        }
    }
}
