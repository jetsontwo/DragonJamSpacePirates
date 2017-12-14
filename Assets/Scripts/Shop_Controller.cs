using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Controller : MonoBehaviour {

    private bool player_in_zone = false;
    public GameObject shop_ui;
    public GameObject game_controller;
    public GameObject instruction;
    public Text coins;
    public Text score;

    public Text speed_text, attack_rate_text, cannon_count_text;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("score", 0);

    }

    // Update is called once per frame
    void Update () {
        coins.text = "Booty: " + PlayerPrefs.GetInt("coins") + " Doubloons";
        score.text = "Score: " + PlayerPrefs.GetInt("score");
		if(player_in_zone)
        {
            if(Input.GetKeyDown(KeyCode.E) && !shop_ui.activeSelf)
            {
                open_shop();
            }
            else if(shop_ui.activeSelf && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E)))
            {
                close_shop();
            }
        }

        speed_text.text = "Increase Speed: $" + PlayerPrefs.GetInt("speed_cost");
        attack_rate_text.text = "Increase Firing Rate: $" + PlayerPrefs.GetInt("attack_rate_cost");
        cannon_count_text.text = "Increase Cannon Count: $" + PlayerPrefs.GetInt("cannon_count_cost");
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            player_in_zone = true;
            instruction.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if(player_in_zone)
        {
            if (c.tag == "Player")
            {
                close_shop();
                instruction.SetActive(false);
                player_in_zone = false;
            }
        }
    }


    private void open_shop()
    {
        shop_ui.SetActive(true);
        game_controller.GetComponent<Custom_Cursor>().show_cursor();
    }

    private void close_shop()
    {
        shop_ui.SetActive(false);
        game_controller.GetComponent<Custom_Cursor>().hide_cursor();
    }
}
