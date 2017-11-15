using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    [Range(0, 10)]
    public float maxSpeed;
    public Vector3 InputVec;
    public Vector3 velocity;
    public float accel;
    // Use this for initialization
    void Start()
    {
        if (!GetComponent<Rigidbody>())
            rigidbody = gameObject.AddComponent<Rigidbody>();
        else
        {
            rigidbody = GetComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    void Update()
    {


        float v = Input.GetAxis("Vertical") * maxSpeed;
        float h = Input.GetAxis("Horizontal") * maxSpeed;
        InputVec = new Vector3(h, 0, v);
        //rigidbody.AddForce(h, 0, v, ForceMode.Acceleration);
        
        if (InputVec.magnitude > 0)
        {
            accel += Time.deltaTime;
            accel = Mathf.Clamp(accel, 0, maxSpeed);
            rigidbody.velocity = (InputVec* accel);
        }
        else
        {

            accel -= Time.deltaTime;
            accel = Mathf.Clamp(accel, 0, maxSpeed);
            rigidbody.velocity = (InputVec * accel);
        }
        velocity = rigidbody.velocity;
        transform.forward = rigidbody.velocity.normalized;
    }
}
