using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float mainThrust = 300f;
    float rotationThrust = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(rotationThrust);
        } else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThrust) {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
