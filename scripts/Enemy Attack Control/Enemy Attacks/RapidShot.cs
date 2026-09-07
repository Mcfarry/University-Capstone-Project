using UnityEngine;

public class RapidShot : EnemyAttack
{
    [SerializeField] private float displacementFromCentre;
    [SerializeField] private float timeToLive;
    [SerializeField] private int bulletCount;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speed;
    public override void Attack(GameObject attacker)
    {
        origin = attacker.transform.Find("Gun");
        GameObject shotBullet = Instantiate(bullet.gameObject, origin.position, Quaternion.LookRotation(attacker.transform.forward));
        var bulletScript = shotBullet.GetComponent<Bullet>();
        bulletScript.hostile = true;
        bulletScript.direction = attacker.transform.forward;
        bulletScript.timeToLive = timeToLive;
        bulletScript.speed = speed;
    }
}
