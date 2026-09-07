using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int setHeight;
    [SerializeField] private int setDistance;
    [SerializeField] private float smoothTime;
    private Vector3 offset;
    private Vector3 currentVelocity = Vector3.zero;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = new Vector3(0,setHeight,-setDistance);
        Vector3 targetPos = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothTime);
    }
}
