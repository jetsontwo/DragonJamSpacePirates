using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    public GameObject to_follow;
    public float follow_dist, follow_speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        float distance = Vector2.Distance(transform.position, to_follow.transform.position);

        if(distance > follow_dist)
        {
            float x_dif, y_dif;

            x_dif = transform.position.x - to_follow.transform.position.x;
            y_dif = transform.position.y - to_follow.transform.position.y;
            transform.position = new Vector3(transform.position.x - x_dif / follow_speed * Time.deltaTime, transform.position.y - y_dif / follow_speed * Time.deltaTime, -10);
            if (transform.position.x > 13.1f)
                transform.position -= new Vector3(transform.position.x - 13.1f, 0);
            else if (transform.position.x < -13.1f)
                transform.position += new Vector3(Mathf.Abs(transform.position.x + 13.1f), 0);

            if (transform.position.y > 14.8)
                transform.position -= new Vector3(0, transform.position.y - 14.8f);
            else if (transform.position.y < -14.8)
                transform.position += new Vector3(0, Mathf.Abs(transform.position.y + 14.8f));
        }
	}
}
