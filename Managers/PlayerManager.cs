using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : UnitManager
{
    public Transform playerPos;
    [SerializeField] private float invulnerabilityTime;
    private bool invulnerable;
    public bool playerDeath = false;

    void Start()
    {
        playerDeath = false;
        playerPos = gameObject.transform;
    }

    void Update()
    {
        playerPos = gameObject.transform;
    }

    public override void DamageUnit(int damageVal)
    {
        if(invulnerable) return;
        health -= damageVal;
        StartCoroutine("InvulnerabilityTimer");
        if(health <= 0) killUnit();
    }

    private IEnumerator InvulnerabilityTimer()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        invulnerable = false;
    }

    void killUnit()
    {
        gameObject.SetActive(false);
        playerDeath = true;
    }
}
