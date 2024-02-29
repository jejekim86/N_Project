using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Object/Monster Data", order = 1)]
public class MonsterData : ScriptableObject
{
    [SerializeField] Sprite m_sprite;
    [SerializeField] string name;
    public Sprite M_sprite => m_sprite;
    public string Name => name;
}
