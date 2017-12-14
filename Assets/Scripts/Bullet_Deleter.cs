using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Deleter : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.tag == "Good_Bullet" || c.tag == "Bad_Bullet")
        {
            c.gameObject.SetActive(false);
        }
    }
}
