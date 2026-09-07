using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public EnemyManager[] enemies;
    public AutomaticDoorOpen[] doors;
    public TriggerDetect[] triggers;
    private bool triggered = false;
    private bool combatFinished = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkTriggers();
        checkEnemies();
    }

    private void checkEnemies()
    {
        if(combatFinished) return;
        int aliveEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].dead) aliveEnemies += 1;
        }

        if (aliveEnemies == 0)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].combatLocked = false;
            }
            combatFinished = true;
        }
        

    }

    void checkTriggers()
    {
        if (triggered) return;
        for (int i = 0; i < triggers.Length; i++)
        {
            if(triggers[i].triggerEntered)
            {
                for (int j = 0; j < doors.Length; j++)
                {
                    StartCoroutine(doors[j].CloseDoor());
                    doors[j].combatLocked = true;
                }
                triggered = true;
                return;
            }
        }
        
    }

}
