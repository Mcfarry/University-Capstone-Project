using UnityEngine;

[CreateAssetMenu]
public class PlayerShotgun : PlayerAttack
{
[SerializeField] private float displacementFromCentre;
    private int separationAngle;
    private int facingAngle;
    [SerializeField] private float timeToLive;
    [SerializeField] private int bulletCount;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speed;
    [SerializeField] private int coneSize;
    [SerializeField] private int angleOffset;

    public override void Attack(GameObject attacker)
    {
        separationAngle = coneSize/bulletCount;
        for(int i = 0; i < bulletCount; i++)
        {
            facingAngle = separationAngle * i;
            origin = attacker.transform.Find("Gun");
            GameObject shotBullet = Instantiate(bullet.gameObject, origin.position, Quaternion.LookRotation(attacker.transform.forward));
            var bulletScript = shotBullet.GetComponent<Bullet>();
            bulletScript.hostile = false;
            bulletScript.timeToLive = timeToLive;
            bulletScript.speed = speed;

            shotBullet.transform.RotateAround(attacker.transform.position,Vector3.up, facingAngle - angleOffset);
            shotBullet.transform.position += shotBullet.transform.forward * displacementFromCentre;
            bulletScript.direction = -(attacker.transform.position - shotBullet.transform.position).normalized;

        }
        
    }
}
