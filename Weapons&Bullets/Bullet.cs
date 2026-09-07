using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 direction;
    public float speed;
    private Vector3 velocity;
    public bool hostile;
    public int damage = 10;
    public float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }


    private void OnTriggerEnter(Collider other) //Bullet collisions with other objects
    {
        UnitManager unit = other.GetComponent<UnitManager>();
        if (unit != null && unit.hostile != hostile)
        {
            unit.DamageUnit(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy" && other.gameObject.tag != "Attack"  && other.gameObject.tag != "Detection" && other.gameObject.tag != "Event Trigger")
        { //Can probably be improved.
            Destroy(gameObject);
        }
    }
}
