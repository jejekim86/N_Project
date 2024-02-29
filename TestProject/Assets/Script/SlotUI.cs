using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }


    public void SetImage(int i) // 나중에 맵 스프라이트랑 아이템 스프라이트 분류해야함
    {
        if(image)
        image.sprite = GameMgr.Instance.Getflatteneds(i);
    }

    public void SetAnimationdata()
    {
    }


}
