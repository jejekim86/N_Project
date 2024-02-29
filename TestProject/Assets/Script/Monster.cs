using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] [Range(0.12f, 1.0f)] float movespeed;
    Vector2 movedirection;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        transform.position = new Vector2(0.13f, 1f);
    }


    public void TargetDamage()
    {
        animator.SetBool("IsAttacked", true);
    }
   
}
