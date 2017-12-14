using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject[] spawn_locations;
    public int[] number_of_ufos;
    public GameObject ufo;
    public int[] number_of_ships;
    private int current_wave = -1;
    private int rand_loc;
    private GameObject[] current_enemies = new GameObject[50];
    private int cur_enemy_index = 0;
	
    void Start()
    {
        next_round();
    }

	public void next_round()
    {
        current_enemies = new GameObject[50];
        cur_enemy_index = 0;
        if(current_wave < number_of_ufos.Length-1)
            current_wave++;
        StartCoroutine(spawn_ufo());
    }


    private IEnumerator spawn_ufo()
    {
        for(int i = 0; i < number_of_ufos[current_wave]; ++i)
        {
            rand_loc = Random.Range(0, spawn_locations.Length - 1);
            current_enemies[cur_enemy_index++] = Instantiate(ufo, spawn_locations[rand_loc].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }

    }

    void Update()
    {
        bool still_alive = false;
        for(int i = 0; i < cur_enemy_index; ++i)
        {
            if (current_enemies[i].activeSelf)
                still_alive = true;
        }

        if(!still_alive)
        {
            for (int i = 0; i < cur_enemy_index; ++i)
            {
                Destroy(current_enemies[i]);
            }
            next_round();
        }
    }
}
