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


    // 게임 맵 오브젝트를 프리팹 시켜서 맵데이터에 저장해서 가져다가 쓰겠끔
}
