using UnityEngine;
using UnityEngine.AI;

public class AttackMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public RangerStateManager movingObject;
    private float timeStamp = 0f;
    private float pauseTimeStamp = 0f;
    private int dodgeCount = 0;
    private RandomMovementLocation rml = new RandomMovementLocation();

    void Start()
    {
        agent = movingObject.agent;
        float rdmNo = Random.Range(0f, 2f);
        pauseTimeStamp = Time.time + rdmNo;
    }

    void Update()
    {
        StartDodge();
    }

    void NextDodge()
    {
        

        if(Time.time < timeStamp) return; //Only dodge after a certain amount of time passes
            Vector3 point;
            if (rml.RandomPoint(gameObject.transform.position, movingObject.dodgeRange, out point))
            {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //Makes it visible with a gizmo
                    agent.SetDestination(point);
                    timeStamp = Time.time + movingObject.timeBetweenDodge;
                    dodgeCount++;
            }
    }

    void StartDodge()
    {
        if(Time.time < pauseTimeStamp) return;
        if(dodgeCount == movingObject.maxDodges)
        {
            float rdmNo = Random.Range(0f, 1f);
            pauseTimeStamp = Time.time + movingObject.dodgeGap + rdmNo;
            dodgeCount = 0;
            return;
        }
        NextDodge();
    }

    public void Remove()
    {
        Destroy(this);
    }
}
