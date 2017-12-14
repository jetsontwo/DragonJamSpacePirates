using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    private Rigidbody2D rb;
    public float push_force;
    public float max_vel;
    public int[] cost_list;
    public float[] speed_upgrade_list;
    private int speed_upgrade_count = 0;
    private bool four_way_movement;


    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("speed_cost", cost_list[speed_upgrade_count]);
        rb = GetComponent<Rigidbody2D>();
        four_way_movement = PlayerPrefs.GetInt("four_way_movement") == 1 ? true : false;
	}
	
	// Update is called once per frame
	void Update () {

        
        if(four_way_movement)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg, Vector3.forward), .06f);

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * Time.deltaTime * push_force);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-Vector2.up * Time.deltaTime * push_force);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-Vector2.right * Time.deltaTime * push_force);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * Time.deltaTime * push_force);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.right * Time.deltaTime * push_force);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
        }


        if(rb.velocity.magnitude > max_vel)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, max_vel);
        }

	}

    public void increase_speed()
    {
        if (speed_upgrade_count != speed_upgrade_list.Length - 1 && PlayerPrefs.GetInt("coins") >= cost_list[speed_upgrade_count])
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - cost_list[speed_upgrade_count]);
            max_vel = speed_upgrade_list[++speed_upgrade_count];
            if (speed_upgrade_count < 4)
                PlayerPrefs.SetInt("speed_cost", cost_list[speed_upgrade_count]);
            else
                PlayerPrefs.SetInt("speed_cost", 0);
        }
    }
}
