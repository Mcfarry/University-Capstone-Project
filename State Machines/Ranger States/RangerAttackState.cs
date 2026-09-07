using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RangerAttackState : RangerBaseState
{
private NavMeshAgent agent;
    public AttackMovement moveController;
    public override void EnterState(RangerStateManager ranger)
    {
        ranger.attackController.currentState = "attack";
        agent = ranger.agent;
        ranger.attackController.StartAttacking();
        agent.updateRotation = false;
        ranger.AddComponent<AttackMovement>();
        moveController = ranger.GetComponent<AttackMovement>();
        moveController.movingObject = ranger;
    }

    public override void UpdateState(RangerStateManager ranger)
    {

        //Change state checks.
        if(ranger.playerDetectPos == null)
        {
            ranger.attackController.StopAttacking();
            agent.updateRotation = true;
            moveController.Remove();
            ranger.SwitchState(ranger.patrolState);
        }
        else
        {

            //Face the player with a set turning speed.
            Vector3 normDirection = (ranger.playerDetectPos.position - ranger.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(normDirection.x,0, normDirection.z));
            ranger.transform.rotation = Quaternion.Slerp(ranger.transform.rotation, lookRotation, Time.deltaTime * ranger.turningSpeed);

            //Switch back to pursue state if outside optimal range.
            float playerDistance = Vector3.Distance(ranger.transform.position, ranger.playerDetectPos.position);

            if(playerDistance > ranger.optimalRange + 2)
            {
                moveController.Remove();
                ranger.SwitchState(ranger.pursueState);
            }
            if(!ranger.GetComponent<EnemyManager>().canSeePlayer)
            {
                moveController.Remove();
                ranger.SwitchState(ranger.pursueState);
            }
        }


    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //Some random location in the sphere idk
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        { 
            //the 1.0f is the max distance
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}
