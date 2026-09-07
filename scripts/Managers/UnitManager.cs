using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool hostile;
    public bool dead = false;
    [SerializeField] private int scoreOnDeath;
    [SerializeField] public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            gameManager.score += scoreOnDeath;
            dead = true;
            gameObject.SetActive(false);
            
        }
    }

    public virtual void DamageUnit(int damageVal)
    {
        health -= damageVal;
    }


}
