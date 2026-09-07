using UnityEngine;
using UnityEngine.AI;

public class RangerStateManager : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    public RangerBaseState currentState;
    public RangerPatrolState patrolState = new RangerPatrolState();
    public RangerPursueState pursueState = new RangerPursueState();
    public RangerAttackState attackState = new RangerAttackState();
    [HideInInspector] public AIAttackController attackController;
    public float turningSpeed;
    public float optimalRange;
    public float patrolRange;
    public float dodgeRange;
    public Transform patrolOrigin;
    public float timeBetweenPatrol;
    public float timeBetweenDodge;
    public float dodgeGap;
    public int maxDodges;
    public float directionRandomizationFactor;
    [HideInInspector] public Transform playerDetectPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attackController = GetComponent<AIAttackController>();
        attackController.stateManager = this;
        currentState = patrolState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(RangerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
