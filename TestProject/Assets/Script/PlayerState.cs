using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public int attackpow { get; protected set; }
    public int attackspeed {get;protected set;}
    public int earngold {get;protected set;}
    public int earngoldspeed {get;protected set;}
    public int gold {get;protected set;}
    public int staticattack {get;protected set;}
    
    protected virtual void Initialize()
    {
        attackpow = 0;
        attackspeed = 0;
        earngold = 0;
        earngoldspeed = 0;
        gold = 0;
        staticattack = 0;
    }

}
