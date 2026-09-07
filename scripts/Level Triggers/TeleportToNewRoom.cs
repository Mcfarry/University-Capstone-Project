using UnityEngine;

public class TeleportToNewRoom : MonoBehaviour
{
    public GameObject exitPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = exitPoint.transform.position;
        }
    }
}
