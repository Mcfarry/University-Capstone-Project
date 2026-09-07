using UnityEngine;

[CreateAssetMenu]
public class AreaBurst : EnemyAttack
{
    [SerializeField] private float displacementFromCentre;
    private int separationAngle;
    private int facingAngle;
    [SerializeField] private float timeToLive;
    [SerializeField] private int bulletCount;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speed;
    public override void Attack(GameObject attacker)
    {
        separationAngle = 360/bulletCount;
        for(int i = 0; i < bulletCount; i++)
        {
            facingAngle = separationAngle * i;
            origin = attacker.transform.Find("Gun");
            GameObject shotBullet = Instantiate(bullet.gameObject, origin.position, Quaternion.LookRotation(attacker.transform.forward));
            var bulletScript = shotBullet.GetComponent<Bullet>();
            bulletScript.hostile = true;
            bulletScript.timeToLive = timeToLive;
            bulletScript.speed = speed;

            shotBullet.transform.RotateAround(attacker.transform.position,Vector3.up, facingAngle);
            shotBullet.transform.position += shotBullet.transform.forward * displacementFromCentre;
            bulletScript.direction = -(attacker.transform.position - shotBullet.transform.position).normalized;

        }
    }
}
