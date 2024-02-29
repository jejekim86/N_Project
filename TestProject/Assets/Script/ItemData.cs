using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/Item Data", order = 2)]

public class ItemData : ScriptableObject
{
    [SerializeField] Sprite itemsprite;
    [SerializeField] string name;
    [SerializeField] int damage;
    [SerializeField] int critical;
    [SerializeField] int cost;
    public Sprite ItemSprite => itemsprite;
    public string Name => name;
    public int Damage => damage;
    public int Critical => critical;
    public int Cost => cost;
}
