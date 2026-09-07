using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public NavMeshAgent agent;
    private float TimeStamp = 0f;
    private RandomMovementLocation rml = new RandomMovementLocation();
    public RangerStateManager movingObject;
    private float rdmNo;

    void Start()
    {
        agent = movingObject.agent;
        rdmNo = Random.Range(0f,2f);
    }

    void Update()
    {
        NextPatrol();
    }

    void NextPatrol()
    {
        
        if(Time.time < TimeStamp + rdmNo) return; //Only patrol after a certain amount of time passes (a random modifier makes enemys move at different times)
        Vector3 point;
        rdmNo = Random.Range(0f,2f);
        if (rml.RandomPoint(movingObject.patrolOrigin.position, movingObject.patrolRange, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //Makes it visible with a gizmo
            agent.SetDestination(point);
            TimeStamp = Time.time + movingObject.timeBetweenPatrol;
        }
    }
    
    public void Remove()
    {
        Destroy(this);
    }
}

//90% of this is straight out of Unity documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
