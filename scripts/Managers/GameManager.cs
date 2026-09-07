using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerManager playerManager;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private HealthBarManager healthBar;
    public int score;
    private bool isPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject DeathMenu;
    [SerializeField] private GameObject HUD;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(playerManager.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        setText();
        setHealth();
        if(playerManager.playerDeath == true)
        {
            playerDeath();
        }
    }

    private void setText()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "" + playerManager.health;
    }

    private void setHealth()
    {
        healthBar.setHealth(playerManager.health);
    }

    public void togglePause()
    {
        if(isPaused)
        {
            pauseMenu.SetActive(false);
            HUD.SetActive(true);
            Time.timeScale = 1f;
            isPaused = false;

        } else
        {
            pauseMenu.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
        }
            
    }

    public void playerDeath()
    {
        DeathMenu.SetActive(true);      
        HUD.SetActive(false); 
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
