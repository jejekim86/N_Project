using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public enum StateType
{
    attacktype,
    attackspeedtype,
    earngoldspeedtype,
    staticattacktype,
    earnpricegoldtype
}
public sealed class GameMgr : MonoBehaviour
{
    [SerializeField] GameMapMgr mapMgr;
    [SerializeField] Player player;
    private static GameMgr instance = null;
    public BigInteger gold { get; private set; }
    public static GameMgr Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameMgr>();
                if (!instance) instance = new GameObject("GameManager").AddComponent<GameMgr>();
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

    private void Start()
    {
        mapMgr.SetData(0);
        MonsterMgr.Instance.Spawn(0);
    }

    private void FixedUpdate()
    {
        mapMgr.StartScrolling();
    }

    public void BuyState(StateType stateType)
    {
        if(gold < player.SetPlayerCost(stateType))
        player.SetStateData(stateType);
    }

    public void SetmapData(int num)
    {
        if (mapMgr.mapIndex == num) return;

        mapMgr.SetData(num);
    }

    public Sprite Getflatteneds(int i)
    {
        return mapMgr.Getflattened(i);
    }

}
