using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topKontrol : MonoBehaviour
{

    public float speed = 2;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movee = new Vector3(1.0f,0.0f,1.0f);
        rb.AddForce(movee*speed);
    }
}
