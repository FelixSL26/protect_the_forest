using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text bananaDisp;
    public int startingSunAmnt;
    public int BananaAmount = 0;
    // Start is called before the first frame update

    void Start()
    {
        AddBanana(startingSunAmnt);
    }

    public void AddBanana(int amnt)
    {
        BananaAmount += amnt;
        bananaDisp.text = "" + BananaAmount;
    }

    public void DeductBanana(int amnt)
    {
        BananaAmount -= amnt;
        bananaDisp.text = "" + BananaAmount;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
