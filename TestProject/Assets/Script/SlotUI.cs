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


    public void SetImage(int i) // ���߿� �� ��������Ʈ�� ������ ��������Ʈ �з��ؾ���
    {
        if(image)
        image.sprite = GameMgr.Instance.Getflatteneds(i);
    }

    public void SetAnimationdata()
    {
    }


}
