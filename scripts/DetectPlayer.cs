using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private Ray vision;
    private Transform parentObj;
    private Transform playerPos;
    private bool inRange = false;
    private float timeStamp = 0;
    private float timeToLose;
    private bool timerRunning = false;
    private EnemyManager manager;

    void Start()
    {
        parentObj = transform.parent;
        manager = parentObj.GetComponent<EnemyManager>();
        timeToLose = manager.timeToLose;
    }

    void FixedUpdate()
    {
        LOSVision();
    }

    private void OnTriggerEnter(Collider other) //Detection needs future proofing!!!! currently is hard coded for specifically enemies with RangerStateManager
    {
        if(other.tag == "Player")
        {
            inRange = true;
            playerPos = other.transform;            
        }
    }

    private void OnTriggerExit(Collider other) //Needs changing to only focus on the detected player rather than any player. Also a future proofing fix.
    {
        if(other.tag == "Player")
        {
            inRange = false;
            DetectionLossTimer();
        }
    }

    private void LOSVision() //Detection needs future proofing!!!! currently is hard coded for specifically enemies with RangerStateManager
    {
        if(inRange == false) return;

        vision.origin = parentObj.transform.position;
        RaycastHit visionDetect;
        Vector3 visionDirection = (playerPos.position - parentObj.transform.position).normalized;
        vision.direction = visionDirection;

        if(Physics.Raycast(vision, out visionDetect, 20))
        {
            Debug.DrawLine(vision.origin, visionDetect.point, Color.magenta);
            if(visionDetect.collider.tag == "Player")
            {
                timerRunning = false;
                manager.canSeePlayer = true;
                parentObj.GetComponent<RangerStateManager>().playerDetectPos = playerPos;
            }
            else
            {
                DetectionLossTimer();
            }
        }
        else
        {
            DetectionLossTimer();
        }
    }

    private void DetectionLossTimer() //Detection needs future proofing!!!! currently is hard coded for specifically enemies with RangerStateManager
    {
        manager.canSeePlayer = false;
        if(!timerRunning){
            timerRunning = true;
            timeStamp = Time.time + timeToLose;
            return;
        }
        if(Time.time < timeStamp) return;
        Debug.Log("lost player");
        //playerPos = null;
        parentObj.GetComponent<RangerStateManager>().playerDetectPos = null;
        timerRunning = false;
    }
        
}
