using System.Collections;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [HideInInspector] public string currentState;
    public bool canAttack = false;
    [SerializeField] private PlayerAttack[] playerAttacks;
    private GameObject attacker;

    void Start()
    {
        attacker = gameObject;
        resetCooldown();
    }

    public void PerformAttack(int bindNo)
    {
        if(playerAttacks[bindNo-1] == null) return;
        if(playerAttacks[bindNo-1].cooldownRunning) return;
        StartCoroutine(playerAttacks[bindNo-1].CooldownTimer());
        playerAttacks[bindNo-1].Attack(attacker);
    }

    public void resetCooldown()
    {
        foreach (PlayerAttack e in playerAttacks)
        {
            e.cooldownRunning = false;
        }
    }
}
