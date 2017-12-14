using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Enemies : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Enemy")
        {
            c.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
