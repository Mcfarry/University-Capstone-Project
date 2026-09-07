using Unity.VisualScripting;
using UnityEngine;

public class RangerPatrolState : RangerBaseState
{
    public RandomPatrol patrolController;
    public override void EnterState(RangerStateManager ranger)
    {
        ranger.attackController.currentState = "patrol";
        ranger.AddComponent<RandomPatrol>();
        patrolController = ranger.GetComponent<RandomPatrol>();
        patrolController.movingObject = ranger;
    }

    public override void UpdateState(RangerStateManager ranger)
    {
        if(ranger.playerDetectPos != null)
        {
            patrolController.Remove();
            ranger.SwitchState(ranger.pursueState);
        }
    }
}
