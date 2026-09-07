using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float currentTime;
    private bool runningTimer = false;
    [SerializeField] private Gun gun;
    [SerializeField] private EnemyManager enemyManager;
    public bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator TimedCycle(float chosenTime)
    {
        currentTime = chosenTime;
        while(currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        runningTimer = false;
    }

    private void Shoot()
    {
        if (runningTimer)
        {
            return;
        }
        
        runningTimer = true;
        StartCoroutine(TimedCycle(1f));
        gun.Shoot();
    }
}
