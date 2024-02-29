using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour
{
    [SerializeField] Item[] items;
    Dictionary<string, Item> ItemDic = new Dictionary<string, Item>();
    private static ItemMgr instance = null;
    public static ItemMgr Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<ItemMgr>();
                if (!instance) instance = new GameObject("ItemManager").AddComponent<ItemMgr>();
                instance.Initialized();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (this != Instance)
            Destroy(gameObject);
    }

    private void Initialized()
    {
        foreach (var item in items)
        {
            if (!ItemDic.ContainsKey(item.GetName()))
                ItemDic.Add(item.GetName(), item);
        }
        
    }

    public AnimationClip GetAnimationsClip(int i)
    {
        return items[i].GetAnimationClip();
    }

    public Sprite GetItemSprite(int i)
    {
        return items[i].GetSprite();
    }
}
