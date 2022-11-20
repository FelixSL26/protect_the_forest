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
            Debug.Log("monkey null");
            if (GameObject.FindGameObjectWithTag("Monkey") != null)
            {
                monkey = GameObject.FindGameObjectWithTag("Monkey");
                monkey.transform.SetParent(this.transform);
                Debug.Log("test");
                monkey.transform.localPosition = Vector3.zero;
            }

        }
    }

}
