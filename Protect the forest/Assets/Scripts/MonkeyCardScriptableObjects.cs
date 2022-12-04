using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cards/Monkey Card", fileName ="New Monkey Card")]


public class MonkeyCardScriptableObjects : ScriptableObject
{
    public Sprite monkeyIcon;
    public Sprite monkeySprite;
    public int cost;
    public float cooldown;
    public bool isBanana;
    public BananaSpawner bananaSpawnerTemplate;

    public Vector2 size;
}
