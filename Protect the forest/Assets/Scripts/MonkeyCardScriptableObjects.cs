using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cards/Monkey Card", fileName ="New Monkey Card")]


public class MonkeyCardScriptableObjects : ScriptableObject
{
    public Sprite monkeyIcon;
    public int cost;
    public float cooldown;
}
