using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour, IPoolingObject
{
    [SerializeField] Animator animator;

    public void Initialize()
    {
    }

}
