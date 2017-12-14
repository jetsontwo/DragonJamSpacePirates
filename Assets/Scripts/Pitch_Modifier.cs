using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch_Modifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioSource a = GetComponent<AudioSource>();
        a.pitch = Random.Range(0.8f, 1.1f);
	}
}
