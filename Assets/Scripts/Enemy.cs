using System;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float starthealth = 100;
    private float health;
    public int worth = 50;


    public int value = 50;

    [Header("Unity stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = starthealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / starthealth;

        if (health <= 0f && !isDead)
        {
            Die();
        }
    }

    void Die()
    {

        isDead = true;
        PlayerStats.Money += worth;

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
