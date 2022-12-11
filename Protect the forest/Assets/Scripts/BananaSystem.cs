using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaSystem : MonoBehaviour
{
    public int SunValue;

    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<GameManager>().AddSun(SunValue);

        Destroy(this.gameObject);
    }
}
