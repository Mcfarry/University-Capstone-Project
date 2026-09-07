using UnityEngine;

[CreateAssetMenu]
public class PlayerStraightShot: PlayerAttack
{
    [Tooltip("How quick the bullet travels.")]
    public float speed;
    [Tooltip("How long a bullet lives until it is destroyed.")]
    public float timeToLive;
    [Tooltip("What bullet will be shot.")]
    public Bullet bullet;
    [Tooltip("How many bullets will be fired at once.")]
    public int bulletCount;
    public override void Attack(GameObject attacker)
    {
        Vector3 displacement = new Vector3(0,0,0);
        for(int i = 1; i < bulletCount + 1; i++)
        {
            origin = attacker.transform.Find("Gun");
            GameObject shotBullet = Instantiate(bullet.gameObject, origin.position, Quaternion.LookRotation(attacker.transform.forward));
            var bulletScript = shotBullet.GetComponent<Bullet>();
            bulletScript.hostile = false;
            bulletScript.direction = attacker.transform.forward;
            bulletScript.timeToLive = timeToLive;
            bulletScript.speed = speed;

            if(bulletCount % 2 == 0)
            {
                if(i % 2 == 0)
                {
                    displacement = shotBullet.transform.right * (i * 0.2f);
                    displacement += -shotBullet.transform.right * 0.2f;
                }
                else
                {
                    displacement = -shotBullet.transform.right * ((i * 0.2f) - 0.2f);
                    displacement += -shotBullet.transform.right * 0.2f;
                }
            }
            else
            {
                if(i % 2 == 0)
                {
                    displacement = shotBullet.transform.right * (i * 0.2f);
                }
                else
                {
                    displacement = -shotBullet.transform.right * ((i * 0.2f) - 0.2f);
                }
            }

            shotBullet.transform.position += displacement;


        }
        
    }
}
