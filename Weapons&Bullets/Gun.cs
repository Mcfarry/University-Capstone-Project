using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    [SerializeField] private float fireRate; //bullets per second.
    private float shootTime = 0f;
    [SerializeField] public bool hostile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Shoot() //Creates an instance of a bullet at gun position.
    {
        GameObject shotBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        var bulletScript = shotBullet.GetComponent<Bullet>();
        bulletScript.hostile = hostile;
        bulletScript.direction = transform.forward;
    }

    public void ShootAtRate() //Sets the gun to fire at a set fire rate (bullets per second).
    {
        if(shootTime < Time.time)
        {
            Shoot();
            shootTime = Time.time + 1/fireRate;
        }
        
    }

}
