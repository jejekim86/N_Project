using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectMgr : MonoBehaviour
{
    [SerializeField] ObjectPool<EffectObject>[] EffectPools;
    List<EffectObject> EffectObjects;
    static EffectMgr instance = null;

    public static EffectMgr Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<EffectMgr>();
                if (!instance) instance = new GameObject("EffectManager").AddComponent<EffectMgr>();
                instance.Initialized();
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
        foreach (var effect in EffectPools)
        {
            effect.Initialize();
        }
    }
    public void SetEffect()
    {
        if (EffectPools[0].GetObject(out EffectObject item))
        {
            EffectObjects.Add(item);
        }
    }
}
