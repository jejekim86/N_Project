using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public interface IPoolingObject
{
    void Initialize();
}
[System.Serializable]

public class ObjectPool<T> where T : MonoBehaviour, IPoolingObject
{
    [SerializeField] T targetObject;
    [SerializeField][Range(1, 100)] int poolingAmount = 1;
    Transform containerObject;
    Queue<T> objectPool;
    public bool Initialize(T value = null)
    {
        if (value) targetObject = value;

        if (!targetObject || containerObject) return false;
        if (1 > poolingAmount) poolingAmount = 1;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("Object Pool Container : ");
        sb.Append(targetObject.name);
        containerObject = new GameObject(sb.ToString()).transform;
        objectPool = new Queue<T>();
        MakeAndPooling();
        return true;
    }
    bool MakeAndPooling()
    {
        if (!containerObject) return false;
        T poolObject;
        for (int i = 0; poolingAmount > i; i++)
        {
            poolObject = MonoBehaviour.Instantiate(targetObject, containerObject);
            poolObject.name = targetObject.name;
            poolObject.Initialize();
            poolObject.gameObject.SetActive(false);
            objectPool.Enqueue(poolObject);
        }
        return true;
    }
    /// <summary> item �ϳ��� Pool���� ���� Ȱ��ȭ ��Ų��. </summary>
    public bool GetObject(out T item)
    {
        item = null;
        if (!containerObject) return false;
        if (0 >= objectPool.Count)
        {
            if (!MakeAndPooling()) return false;
        }
        item = objectPool.Dequeue();
        item.gameObject.SetActive(true);
        return true;
    }
    /// <summary> �ش� Ǯ�� ������ �������� �´��� Ȯ��. </summary>
    public bool CheckItem(T item)
    {
        if (!targetObject) return false;
        return targetObject.name.Equals(item.name);
    }
    /// <summary> item�� ��Ȱ��ȭ ��Ű�� Pool�� �ִ´�. </summary>
    public bool PutInPool(T item)
    {
        if (!(item && containerObject)) return false;
        item.gameObject.SetActive(false);
        objectPool.Enqueue(item);
        return true;
    }
    public bool Destroy()
    {
        if (!containerObject) return false;
        MonoBehaviour.Destroy(containerObject.gameObject);
        containerObject = null;
        objectPool.Clear();
        objectPool = null;
        return true;
    }
    public void ReturnBackPool()
    {
        if (containerObject)
        {
            // ��� �ڽ��� ��ȸ �Ѵ�.
            foreach (Transform child in containerObject)
            {
                if (child.gameObject.activeSelf)
                {
                    if (child.TryGetComponent(out T item)) PutInPool(item);
                }
            }
        }
    }
} // class ObjectPool
