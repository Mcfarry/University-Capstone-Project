using System.Collections;
using UnityEngine;

public abstract class PlayerAttack : ScriptableObject
{
    [Tooltip("The damage of each attack (for each individual bullet if applicable).")]
    public int damage;
    public float cooldownLength;
    public int priority;
    public bool cooldownRunning = false;
    [SerializeField] protected Transform origin;
    public abstract void Attack(GameObject attacker);

    public IEnumerator CooldownTimer()
    {
        if(!cooldownRunning)
        {
            cooldownRunning = true;
            yield return new WaitForSeconds(cooldownLength);
            cooldownRunning = false;
        }
    }
}
