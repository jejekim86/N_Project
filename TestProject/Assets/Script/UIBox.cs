using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum BoxType
{
    PlayerBox,
    ShopBox1,
    ShopBox2,
    MapBox,
    ElseBox,
};
public class UIBox : MonoBehaviour
{
    [SerializeField] BoxType boxType;
    [SerializeField] SlotUI[] slotUIs;
    public void OnToggle(Toggle toggle)
    {
        switch (toggle.isOn)
        {
            case true:
                gameObject.SetActive(true);
                break;
            case false:
                gameObject.SetActive(false);
                break;
        }
    }

    private void Start()
    {
        /*if (slotUIs[0].gameObject.activeSelf)
             slotUIs[0].SetAnimationdata();*/
        SetSlotData();
    }

    private void SetSlotData()
    {
        switch (boxType)
        {
            case BoxType.PlayerBox:
                break;
            case BoxType.ShopBox1:
                break;
            case BoxType.ShopBox2:
                break;
            case BoxType.MapBox:
                for(int i = 0; i < slotUIs.Length; i++)
                    slotUIs[i].SetImage(i);
                break;
            case BoxType.ElseBox:
                break;
        }
    }
}