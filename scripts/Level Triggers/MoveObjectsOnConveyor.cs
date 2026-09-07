using System.Collections;
using UnityEngine;

public class MoveObjectsOnConveyor : MonoBehaviour
{
    public Transform[] movePositions;
    public GameObject spawnObject;
    public float interpolationTime;
    public float timeBetweenSpawn;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(moveTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnMovingObject()
    {
        GameObject movingObject = Instantiate(spawnObject);
        MoveOnConveyor conveyorItem = movingObject.GetComponent<MoveOnConveyor>();
        conveyorItem.movePositions = movePositions;
        conveyorItem.interpolationTime = interpolationTime;
        conveyorItem.timeBetweenSpawn = timeBetweenSpawn;
        yield return null;
    }

    IEnumerator moveTimer()
    {
        StartCoroutine(spawnMovingObject());
        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine(moveTimer());
    }
}
