using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Script : MonoBehaviour {

    public int max_health;
    public int coins_on_death;
    private int cur_health;
    public string hurt_by_tag;
    public GameObject death_explosion;

    public GameObject explosion;
    public GameObject game_over_panel;

	// Use this for initialization
	void Start () {
        cur_health = max_health;
	}

    void take_damage(int damage)
    {
        cur_health -= damage;
        if (transform.tag == "Player")
        {
            PlayerPrefs.SetInt("player_health", cur_health);
            StartCoroutine(Camera.main.GetComponent<Camera_Shake>().Shake());
        }
        if (cur_health <= 0)
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+coins_on_death);
            if (transform.tag == "Player")
            {
                game_over_panel.SetActive(true);
                Cursor.visible = true;
            }
            else
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 100);
            gameObject.SetActive(false);
            Instantiate(death_explosion, transform.position, Quaternion.identity);
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == hurt_by_tag)
        {
            Instantiate(explosion, c.transform.position, Quaternion.identity);
            take_damage(c.GetComponent<Bullet_Controller>().get_damage());
            c.gameObject.SetActive(false);
        }
    }
	
	
}
