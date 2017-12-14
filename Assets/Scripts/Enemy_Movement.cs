using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

    private Rigidbody2D rb;
    public float push_force;
    public float max_vel, distance_between_cap;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update () {
        if(Vector2.Distance(transform.position, player.transform.position) > distance_between_cap)
        {
            if (player.transform.position.y > transform.position.y)
            {
                rb.AddForce(transform.up * Time.deltaTime * push_force);
            }
            if (player.transform.position.y < transform.position.y)
            {
                rb.AddForce(-transform.up * Time.deltaTime * push_force);
            }
            if (player.transform.position.x < transform.position.x)
            {
                rb.AddForce(-transform.right * Time.deltaTime * push_force);
            }
            if (player.transform.position.x > transform.position.x)
            {
                rb.AddForce(transform.right * Time.deltaTime * push_force);
            }
        }


        if (rb.velocity.magnitude > max_vel)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, max_vel);
        }
    }
}
