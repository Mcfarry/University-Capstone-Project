using System.Collections;
using UnityEngine;

public class MoveOnConveyor : MonoBehaviour
{
    public Transform[] movePositions;
    public float interpolationTime;
    public float timeBetweenSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(moveObject());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator moveObject()
    {
        transform.position = movePositions[0].position;
        for(int i = 0; i < movePositions.Length; i++)
        {
            float timeElapsed = 0;
            if(i == movePositions.Length - 1)
            {
                Destroy(gameObject);
                break;
            } 
            while (timeElapsed < interpolationTime)
            {
                float t = timeElapsed / interpolationTime;
                transform.position = Vector3.Lerp(movePositions[i].position, movePositions[i+1].position, t);           
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            
        }
        
        
    }
}
