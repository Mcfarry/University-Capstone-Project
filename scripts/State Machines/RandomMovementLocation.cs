using UnityEngine;
using UnityEngine.AI;

public class RandomMovementLocation
{
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
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
