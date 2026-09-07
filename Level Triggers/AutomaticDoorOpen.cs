using System.Collections;
using UnityEngine;

public class AutomaticDoorOpen : MonoBehaviour
{
    public bool combatLocked = false;
    public bool triggerLocked;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject sealedDoor;
    public float openLength;
    public bool openOnZPlane;
    public float interpolationTime;
    private Vector3 leftDoorOpenedPos;
    private Vector3 rightDoorOpenedPos;
    private Vector3 leftDoorClosedPos;
    private Vector3 rightDoorClosedPos;
    private Vector3 currentLeftPos;
    private Vector3 currentRightPos;

    void Start ()
    {
        leftDoorClosedPos = leftDoor.transform.position;
        rightDoorClosedPos = rightDoor.transform.position;

        if(openOnZPlane == false)
        {
            leftDoorOpenedPos = leftDoor.transform.position + new Vector3(openLength, 0, 0);
            rightDoorOpenedPos = rightDoor.transform.position - new Vector3(openLength, 0, 0);
        }
        else
        {
            leftDoorOpenedPos = leftDoor.transform.position - new Vector3(0, 0, openLength);
            rightDoorOpenedPos = rightDoor.transform.position + new Vector3(0, 0, openLength);
        }
        
    }

    void Update ()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(combatLocked || triggerLocked) return;
        
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine("OpenDoor");  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(combatLocked || triggerLocked) return;

        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine("CloseDoor");   
        }
    }

    IEnumerator OpenDoor()
    {

        float timeElapsed = 0;
        currentLeftPos = leftDoor.transform.position;
        currentRightPos = rightDoor.transform.position;
        while (timeElapsed < interpolationTime)
        {
            float t = timeElapsed / interpolationTime;

            leftDoor.transform.position = Vector3.Lerp(currentLeftPos, leftDoorOpenedPos, t);
            rightDoor.transform.position = Vector3.Lerp(currentRightPos, rightDoorOpenedPos, t);
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        
    }

    public IEnumerator CloseDoor()
    {
        float timeElapsed = 0;
        currentLeftPos = leftDoor.transform.position;
        currentRightPos = rightDoor.transform.position;
        while (timeElapsed < interpolationTime)
        {
            float t = timeElapsed / interpolationTime;

            leftDoor.transform.position = Vector3.Lerp(currentLeftPos, leftDoorClosedPos, t);
            rightDoor.transform.position = Vector3.Lerp(currentRightPos, rightDoorClosedPos, t);
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }
}
