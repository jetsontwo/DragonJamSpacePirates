using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Cursor : MonoBehaviour {

    public Texture2D cursorTexture;

    void Start()
    {
        //Cursor.SetCursor(cursorTexture, new Vector2(20,20), CursorMode.Auto);
        hide_cursor();
    }

    public void hide_cursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void show_cursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
