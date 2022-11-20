using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManagerCollider : MonoBehaviour
{

    public GameObject monkey;
    public bool isOccupied = false;

    void OnMouseOver()
    {
        foreach (CardManager item in GameObject.FindObjectsOfType<CardManager>())
        {
            item.colliderName = this.GetComponent<SlotsManagerCollider>();
            item.isOverCollider = true;
        }


        if (monkey == null)
        {
            if (GameObject.FindGameObjectWithTag("Monkey") != null)
            {
                monkey = GameObject.FindGameObjectWithTag("Monkey");
                monkey.transform.SetParent(this.transform);
                Vector3 pos = new Vector3(0, 0, -1);
                monkey.transform.localPosition = pos;
            }

        }
    }

    private void OnMouseExit()
    {
        //Destroy(monkey);
    } 

}
