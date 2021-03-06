using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.transform.position.z < player.transform.position.z - 10)
        {
            rb.transform.position = new Vector3(Random.Range(-6,18), Random.Range(-20,3), Random.Range(GroundBehaviour.zPosition+50, GroundBehaviour.zPosition+120));
        }
    }
}
