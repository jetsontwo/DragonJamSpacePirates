using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {

    public float left_shoot_timer, right_shoot_timer, reload_time, bullet_speed, life_span;
    public int damage;
    public GameObject bullet_holder;
    private GameObject[] bullet_list;
    private int cur_bullet = 0;

    public float[] reload_upgrade_list;
    private int reload_upgrade_count = 0;
    private int shot_count = 1;
    public int[] cost_list;

    private Rigidbody2D rb;

    public ParticleSystem[] cannon_smokes_left;
    public ParticleSystem[] cannon_smokes_right;

    private AudioSource shoot;

    void Start()
    {
        PlayerPrefs.SetInt("attack_rate_cost", cost_list[reload_upgrade_count]);
        PlayerPrefs.SetInt("cannon_count_cost", cost_list[shot_count]);

        rb = GetComponent<Rigidbody2D>();
        shoot = GetComponent<AudioSource>();
        bullet_list = new GameObject[100];
        int count = 0;
        foreach (Transform child in bullet_holder.transform)
        {
            if(child.CompareTag("Good_Bullet"))
                bullet_list[count++] = child.gameObject;
        }
    }

	
	void Update () {

        if(Input.GetKey(KeyCode.LeftArrow) && left_shoot_timer >= reload_time)
        {
            left_shoot_timer = 0;
            shoot.pitch = Random.Range(0.9f, 1.1f);
            shoot.Play();
            StartCoroutine(Camera.main.GetComponent<Camera_Shake>().little_shake());
            if (shot_count == 1)
            {
                create_bullet(transform.position.x, transform.position.y, transform.up.x, transform.up.y);
                cannon_smokes_left[2].Play();
                
            }
            else if(shot_count == 2)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.5f), transform.position.y - (transform.right.y * 0.5f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.5f), transform.position.y + (transform.right.y * 0.5f), transform.up.x, transform.up.y);
                cannon_smokes_left[0].Play();
                cannon_smokes_left[4].Play();
            }
            else if(shot_count == 3)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.75f), transform.position.y - (transform.right.y * 0.75f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.75f), transform.position.y + (transform.right.y * 0.75f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x, transform.position.y, transform.up.x, transform.up.y);
                cannon_smokes_left[0].Play();
                cannon_smokes_left[2].Play();
                cannon_smokes_left[4].Play();
            }
            else if(shot_count == 4)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.25f), transform.position.y - (transform.right.y * 0.25f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.25f), transform.position.y + (transform.right.y * 0.25f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x - (transform.right.x * 0.75f), transform.position.y - (transform.right.y * 0.75f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.75f), transform.position.y + (transform.right.y * 0.75f), transform.up.x, transform.up.y);
                cannon_smokes_left[0].Play();
                cannon_smokes_left[1].Play();
                cannon_smokes_left[3].Play();
                cannon_smokes_left[4].Play();
            }
            else if(shot_count == 5)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.4f), transform.position.y - (transform.right.y * 0.4f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.4f), transform.position.y + (transform.right.y * 0.4f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x - (transform.right.x * 0.8f), transform.position.y - (transform.right.y * 0.8f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.8f), transform.position.y + (transform.right.y * 0.8f), transform.up.x, transform.up.y);
                create_bullet(transform.position.x, transform.position.y, transform.up.x, transform.up.y);
                cannon_smokes_left[0].Play();
                cannon_smokes_left[1].Play();
                cannon_smokes_left[2].Play();
                cannon_smokes_left[3].Play();
                cannon_smokes_left[4].Play();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && right_shoot_timer >= reload_time)
        {
            right_shoot_timer = 0;
            shoot.pitch = Random.Range(0.9f, 1.1f);
            shoot.Play();
            StartCoroutine(Camera.main.GetComponent<Camera_Shake>().little_shake());
            if (shot_count == 1)
            {
                create_bullet(transform.position.x, transform.position.y, -transform.up.x, -transform.up.y);
                cannon_smokes_right[2].Play();
            }
            else if (shot_count == 2)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.5f), transform.position.y - (transform.right.y * 0.5f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.5f), transform.position.y + (transform.right.y * 0.5f), -transform.up.x, -transform.up.y);
                cannon_smokes_right[0].Play();
                cannon_smokes_right[4].Play();
            }
            else if (shot_count == 3)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.75f), transform.position.y - (transform.right.y * 0.75f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.75f), transform.position.y + (transform.right.y * 0.75f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x, transform.position.y, -transform.up.x, -transform.up.y);
                cannon_smokes_right[0].Play();
                cannon_smokes_right[2].Play();
                cannon_smokes_right[4].Play();
            }
            else if (shot_count == 4)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.25f), transform.position.y - (transform.right.y * 0.25f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.25f), transform.position.y + (transform.right.y * 0.25f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x - (transform.right.x * 0.75f), transform.position.y - (transform.right.y * 0.75f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.75f), transform.position.y + (transform.right.y * 0.75f), -transform.up.x, -transform.up.y);
                cannon_smokes_right[0].Play();
                cannon_smokes_right[1].Play();
                cannon_smokes_right[3].Play();
                cannon_smokes_right[4].Play();
            }
            else if (shot_count == 5)
            {
                create_bullet(transform.position.x - (transform.right.x * 0.4f), transform.position.y - (transform.right.y * 0.4f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.4f), transform.position.y + (transform.right.y * 0.4f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x - (transform.right.x * 0.8f), transform.position.y - (transform.right.y * 0.8f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x + (transform.right.x * 0.8f), transform.position.y + (transform.right.y * 0.8f), -transform.up.x, -transform.up.y);
                create_bullet(transform.position.x, transform.position.y, -transform.up.x, -transform.up.y);
                cannon_smokes_right[0].Play();
                cannon_smokes_right[1].Play();
                cannon_smokes_right[2].Play();
                cannon_smokes_right[3].Play();
                cannon_smokes_right[4].Play();
            }
        }
        left_shoot_timer += Time.deltaTime;
        right_shoot_timer += Time.deltaTime;
	}


    private void create_bullet(float x, float y, float dirx, float diry)
    {
        //adds forcefor bullet kickback
        //rb.AddForce(new Vector2(-dirx * 50f, -diry * 50f));
        if (cur_bullet == bullet_list.Length)
            cur_bullet = 0;
        GameObject b = bullet_list[cur_bullet++];
        b.SetActive(true);
        b.transform.position = new Vector2(x, y);
        b.GetComponent<Bullet_Controller>().init(dirx, diry, bullet_speed, life_span, damage);
    }



    public void increase_reload()
    {
        if (reload_upgrade_count != reload_upgrade_list.Length-1 && PlayerPrefs.GetInt("coins") >= cost_list[reload_upgrade_count])
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - cost_list[reload_upgrade_count]);
            reload_time = reload_upgrade_list[++reload_upgrade_count];
            if (reload_upgrade_count < 3)
                PlayerPrefs.SetInt("attack_rate_cost", cost_list[reload_upgrade_count]);
            else
                PlayerPrefs.SetInt("attack_rate_cost", 0);
        }
    }

    public void increase_shot_count()
    {
        if (shot_count < 5 && PlayerPrefs.GetInt("coins") >= cost_list[shot_count])
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - cost_list[shot_count]);
            shot_count++;
            if (shot_count < 5)
                PlayerPrefs.SetInt("cannon_count_cost", cost_list[shot_count]);
            else
                PlayerPrefs.SetInt("cannon_count_cost", 0);
        }
    }
}
