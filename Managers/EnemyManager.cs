using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : UnitManager
{
    public float timeToLose;
    [HideInInspector] public bool canSeePlayer = false;
    [SerializeField] private int contactDamage;


    void OnCollisionEnter(Collision collision) //Enemy collisions with player cause contact damage.
    {
        if(contactDamage == 0) return;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().DamageUnit(contactDamage);
        }
    }

    public override void DamageUnit(int damageVal)
    {
        health -= damageVal;
    }
}
