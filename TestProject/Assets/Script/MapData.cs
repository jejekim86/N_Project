using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MapData", menuName = "Scriptable Object/Map Data", order = 1)]

public class MapData : ScriptableObject
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] string name;
    [SerializeField] Material materials;

    public Sprite[] Sprites => sprites;
    public Material Materials => materials;
    public string Name => name;


    // ���� �� ������Ʈ�� ������ ���Ѽ� �ʵ����Ϳ� �����ؼ� �����ٰ� ���ڲ�
}
