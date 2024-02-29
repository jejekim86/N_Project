using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] [Range(1, 10)]float movespeed = 0.2f;
    [SerializeField] MeshRenderer meshRenderer;
    private Material material;
    public MeshRenderer SetmeshRenderer() { return meshRenderer; }


    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }



    public void StartScroll()
    {
        material.SetTextureOffset("_MainTex", Vector2.right * Time.time * movespeed);
    }
}
