using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData data;
    [SerializeField] AnimationClip animclip;
    public Sprite GetSprite() => data.ItemSprite;
    public int GetDamage() => data.Damage;
    public int GetCritical() => data.Critical;
    public int GetCost() => data.Cost;
    public string GetName() => data.Name;
    public AnimationClip GetAnimationClip() => animclip;

    public void ItemBuy()
    {

    }
   
}
