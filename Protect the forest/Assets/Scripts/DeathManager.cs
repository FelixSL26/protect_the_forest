using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided Death!");
        if (collision.tag == "Zombie")
        {
            //ending gameover
            SceneManager.LoadScene("GameOver");
            Debug.Log("Died!");
        }
    }

}
