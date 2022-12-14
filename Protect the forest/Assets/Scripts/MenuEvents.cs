using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitButton()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Game Closed!");
    }

}
