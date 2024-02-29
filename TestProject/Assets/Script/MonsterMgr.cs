using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMgr : MonoBehaviour
{
    [SerializeField] Monster[] Monsters;
    private static MonsterMgr instance = null;
    public static MonsterMgr Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<MonsterMgr>();
                if (!instance) instance = new GameObject("MonsterManager").AddComponent<MonsterMgr>();
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
        foreach (var monster in Monsters)
        {
            Instantiate(monster, transform);
            monster.gameObject.SetActive(false);
        }
    }

    public void Spawn(int i)
    {
        Monsters[i].gameObject.SetActive(true);
    }






    public void SetEnemyRemove(Monster monster)
    { 
        monster.gameObject.SetActive(false); // test
    }

}
