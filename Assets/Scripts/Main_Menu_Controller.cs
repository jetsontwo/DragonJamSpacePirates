using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour {

	public void start_game()
    {
        if (!PlayerPrefs.HasKey("four_way_movement"))
            omni_movement();
        SceneManager.LoadScene(1);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void omni_movement()
    {
        PlayerPrefs.SetInt("four_way_movement", 1);
    }
    public void basic_movement()
    {
        PlayerPrefs.SetInt("four_way_movement", 0);
    }
}
