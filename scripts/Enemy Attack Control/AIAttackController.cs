using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class AIAttackController : MonoBehaviour
{
    [HideInInspector] public RangerStateManager stateManager;
    [HideInInspector] public string currentState;
    public bool canAttack = false;
    [SerializeField] private float globalCooldown;
    [SerializeField] private EnemyAttack[] enemyAttacks;
    private EnemyAttack[] enemyAttacksClone;

    void Start()
    {
        CloneSOs();
        //resetCooldown();
        StartCoroutine("AttackTiming");
    }

    private IEnumerator AttackTiming()
    {
        if(canAttack) PerformAttack();
        yield return new WaitForSeconds(globalCooldown);
        StartCoroutine("AttackTiming");
    }

    private void PerformAttack()
    {
        ArrayList availableAttacks = new ArrayList();
        EnemyAttack chosenAttack = null;
        
        foreach(EnemyAttack e in enemyAttacksClone)
        {
            
            if(!e.cooldownRunning)
            {
                
                availableAttacks.Add(e); 
            } 
        }
        foreach(EnemyAttack e in availableAttacks)
        {
            if(chosenAttack == null)  chosenAttack = e;
            if(chosenAttack.priority < e.priority) chosenAttack = e;
        }
        if(chosenAttack == null) return;
        if(currentState == "pursue" && !chosenAttack.attackInPursuit) return;
        StartCoroutine(chosenAttack.CooldownTimer());
        chosenAttack.Attack(stateManager.gameObject);
    }

    public void StartAttacking()
    {
        canAttack = true;
    }

    public void StopAttacking()
    {
        canAttack = false;
    }

    public void resetCooldown()
    {
        foreach (EnemyAttack e in enemyAttacks)
        {
            e.cooldownRunning = false;
        }
    }

    public void CloneSOs()
    {
        enemyAttacksClone = new EnemyAttack[enemyAttacks.Length];
        for(int i = 0; i < enemyAttacks.Length; i++)
        {
            enemyAttacksClone[i] = Instantiate(enemyAttacks[i]);
        }
    }

}