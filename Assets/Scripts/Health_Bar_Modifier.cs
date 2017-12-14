using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_Modifier : MonoBehaviour {

    private RectTransform i;

	// Use this for initialization
	void Start () {
        i = GetComponent<RectTransform>();
        PlayerPrefs.SetInt("player_health", 100);
    }

    // Update is called once per frame
    void Update () {
        i.sizeDelta = new Vector2(PlayerPrefs.GetInt("player_health")*3, i.sizeDelta.y);
	}
}
