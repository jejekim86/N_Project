using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : PlayerState
{
    Animator animator;
    bool attackstate;
    [SerializeField] [Range(0, 10000)]float speed = 10000;
    BigInteger cost;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        attackstate = false;
        cost = 0;
        StartCoroutine(startAttack());
        Initialize();
    }

    IEnumerator startAttack()
    {
        while (true)
        {
            if (attackstate)
                Attack();
            yield return new WaitForSeconds(0.6f);
        }
    }

    public BigInteger SetPlayerCost(StateType stateType)
    {
        switch (stateType)
        {
            case StateType.attacktype:
                return cost + attackpow;
            case StateType.attackspeedtype:
                return cost + attackspeed;
            case StateType.earngoldspeedtype:
                return cost + earngoldspeed;
            case StateType.staticattacktype:
                return cost + staticattack;
            case StateType.earnpricegoldtype:
                return cost + earngold;
        }
        return 0;
    }
    IEnumerator GetCost()
    {
        while(true)
        {
            cost += (BigInteger)earngold;
            yield return new WaitForSeconds(speed - earngoldspeed);
        }
    }

    public void SetStateData(StateType stateType)
    {
        switch (stateType)
        {
            case StateType.attacktype:
                break;
            case StateType.attackspeedtype:
                break;
            case StateType.earngoldspeedtype:
                break;
            case StateType.staticattacktype:
                break;
            case StateType.earnpricegoldtype:
                break;
        }
    }
    public void Attack()
    {
        animator.SetBool("IsInside", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            attackstate = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            attackstate = false;
    }

}