using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolingObject
{
    [Header("Object Pool")]
    [SerializeField] ObjectPool<T>[] objectPools = null;
    public int PoolCount => objectPools.Length;
    public int SpawnCount { get; private set; } = 0;
    protected void InitializeSpawner(object param = null)
    {
        int count = objectPools.Length;
        for (int i = 0; count > i; i++)
        {
            if (!objectPools[i].Initialize())
            {
                // ������ �ڵ��̱� ������ string�� +�����ڸ� �̿��Ͽ� ��ģ ��, ���� �ڵ忡���� �ϸ� �ȵ�!!
                Debug.LogError(name + (i + 1) + "��° Pool ���� ����!!");
            }
        }
    }
    public T Spawn(int index)
    {
        if (0 > index || (objectPools.Length - 1) < index) return null;
        if (objectPools[index].GetObject(out T item))
        {
            SpawnCount++;
            return item;
        }
        return null;
    }
    public bool GiveBackItem(T item)
    {
        int count = objectPools.Length;
        for (int i = 0; count > i; i++)
        {
            if (objectPools[i].CheckItem(item))
            {
                objectPools[i].PutInPool(item);
                SpawnCount--;
                return true;
            }
        }
        return false;
    }
    public void Clear()
    {
        int count = objectPools.Length;
        for (int i = 0; count > i; i++)
        {
            objectPools[i].Destroy();
        }
        SpawnCount = 0;
    }
    public void ReturnPool()
    {
        int count = objectPools.Length;
        for (int i = 0; count > i; i++)
        {
            objectPools[i].ReturnBackPool();
        }
        SpawnCount = 0;
    }
} // class Spawner

