using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameMapMgr : MonoBehaviour
{
    private enum mapterain
    {
        gradiant,
        ground,
        grass,
        sky,
        quad,
    }
    private enum mapdatatype
    {
        mapsprites,
        mapmar,
        mapname,
    }
    [SerializeField] MapData[] mapdata;

    [SerializeField] TextMeshProUGUI mapText;
    [SerializeField] SpriteRenderer[] mapspriterenderer;
    [SerializeField] Sprite[] flatteneds;
    [SerializeField] Scrolling scroll;
    public int mapIndex { get; private set; }
    
    public Sprite Getflattened(int i)
    {
        if (!flatteneds[i]) return null;
        return flatteneds[i]; 
    }
    public void SetData(int num)
    {
        mapIndex = num;
        SetSprite(mapterain.gradiant, mapdata[mapIndex]);
        SetSprite(mapterain.ground, mapdata[mapIndex]);
        SetSprite(mapterain.grass, mapdata[mapIndex]);
        SetSprite(mapterain.sky, mapdata[mapIndex]);
        scroll.SetmeshRenderer().material = mapdata[mapIndex].Materials;

        mapText.text = mapdata[mapIndex].Name;
    }

    private void SetSprite(mapterain type, MapData data)
    {
        if (data.Sprites.Length > (int)type)
            mapspriterenderer[(int)type].sprite = data.Sprites[(int)type];
        else
            mapspriterenderer[(int)type].sprite = null;
    }
    public void StartScrolling()
    {
        scroll.StartScroll();
    }

}
