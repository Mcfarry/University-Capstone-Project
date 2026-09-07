using UnityEngine;
using UnityEngine.AI;

public class RangerPursueState : RangerBaseState
{
    private NavMeshAgent agent;
    public override void EnterState(RangerStateManager ranger)
    {
        ranger.attackController.currentState = "pursue";
        agent = ranger.agent;
        ranger.attackController.StartAttacking();
        agent.updateRotation = false;
    }

    public override void UpdateState(RangerStateManager ranger)
    {

        //Change state checks.
        if(ranger.playerDetectPos == null)
        {
            ranger.attackController.StopAttacking();
            agent.updateRotation = true;
            ranger.SwitchState(ranger.patrolState);
        }
        else
        {

            //Face the player with a set turning speed.
            Vector3 normDirection = (ranger.playerDetectPos.position - ranger.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(normDirection.x,0, normDirection.z));
            ranger.transform.rotation = Quaternion.Slerp(ranger.transform.rotation, lookRotation, Time.deltaTime * ranger.turningSpeed);

            //Update the agent's destination.
            float playerDistance = Vector3.Distance(ranger.transform.position, ranger.playerDetectPos.position);
            if(playerDistance > ranger.optimalRange || ranger.GetComponent<EnemyManager>().canSeePlayer == false)
            {
                agent.SetDestination(ranger.playerDetectPos.position);
            }
            else
            {
                ranger.SwitchState(ranger.attackState);
            }
            
        }

    }
}
