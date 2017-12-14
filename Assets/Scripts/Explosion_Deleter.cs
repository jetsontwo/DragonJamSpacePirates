using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Deleter : MonoBehaviour {

    float timer = 0;

	// Update is called once per frame
	void Update () {
        if (timer >= 2)
            Destroy(gameObject);
        timer += Time.deltaTime;
	}
}
