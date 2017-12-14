using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour {

    public float shoot_timer, reload_time, bullet_speed, life_span, distance_to_shoot;
    public int damage;
    public GameObject bullet_holder;
    private GameObject[] bullet_list;
    private int cur_bullet = 0;
    public GameObject player;
    private AudioSource shoot;

    void Start()
    {
        shoot = GetComponent<AudioSource>();
        bullet_list = new GameObject[20];
        int count = 0;
        foreach (Transform child in bullet_holder.transform)
        {
            if (child.CompareTag("Bad_Bullet"))
                bullet_list[count++] = child.gameObject;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        if (Vector2.Distance(transform.position, player.transform.position) < distance_to_shoot && shoot_timer >= reload_time)
        {
            shoot.pitch = Random.Range(0.9f, 1.1f);
            shoot.Play();
            Vector2 dir = (player.transform.position - (transform.position)).normalized;
            create_bullet(transform.position.x, transform.position.y, dir.x, dir.y);
            shoot_timer = 0;
        }
        shoot_timer += Time.deltaTime;
    }


    private void create_bullet(float x, float y, float dirx, float diry)
    {
        if (cur_bullet == bullet_list.Length-1)
            cur_bullet = 0;
        GameObject b = bullet_list[cur_bullet++];
        b.SetActive(true);
        b.transform.position = new Vector2(x, y);
        b.GetComponent<Bullet_Controller>().init(dirx, diry, bullet_speed, life_span, damage);
    }
}
