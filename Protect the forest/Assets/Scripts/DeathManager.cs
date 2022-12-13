using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided Death!");
        if (collision.tag == "Zombie")
        {
            //ending gameover
            Debug.Log("Died!");
        }
    }

}
