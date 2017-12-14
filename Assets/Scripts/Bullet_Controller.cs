using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    private float life_time= 0, span = 0;
    private int damage;

    // Use this for initialization
    public void init(float dirx, float diry, float speed, float life_span, int d) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(dirx * speed, diry * speed);
        span = life_span;
        life_time = 0;
        damage = d;
	}
	
	// Update is called once per frame
	void Update () {
		if(life_time > span)
        {
            gameObject.SetActive(false);
        }
        life_time += Time.deltaTime;
	}

    public int get_damage()
    {
        return damage;
    }
}
