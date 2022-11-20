using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManagerCollider : MonoBehaviour
{

    public GameObject monkey;

    void OnMouseOver()
    {
        if (monkey == null)
        {
            if (GameObject.FindGameObjectWithTag("Monkey") != null)
            {
                monkey = GameObject.FindGameObjectWithTag("Monkey");
                monkey.transform.SetParent(this.transform);
                monkey.transform.localPosition = Vector3.zero;
            }

        }
    }

}
