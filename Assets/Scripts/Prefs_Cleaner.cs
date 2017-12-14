using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs_Cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
	}

}
