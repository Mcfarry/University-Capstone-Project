using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float width;
    public float height;
    public RectTransform healthBar;
    public void setMaxHealth(float MaxHealth)
    {
        maxHealth = MaxHealth;
    }

    public void setHealth(float Health)
    {
        health = Health;
        float newWidth = (health / maxHealth) * width;
        healthBar.sizeDelta = new Vector2 (newWidth, height);
    }
}
