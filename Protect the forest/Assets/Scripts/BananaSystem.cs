using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int BananaValue;


    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<GameManager>().AddBanana(BananaValue);

        Destroy(this.gameObject);
    }
}
