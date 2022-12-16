using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadLevel01(int index)
    {
        SceneManager.LoadScene("Level01");
    }

    public void LoadMenu(int index)
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Game Closed!");
    }



}
