using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.UI;

public class Enemy : Actor
{
    public float speed = 10f;
    public int health = 100;
    public int value = 50;

    public Slider healthSlider;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    protected override void Start()
    {
        base.Start();

        target = Waypoints.points[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Pause();

        if (!GameManager.isPaused)
        {
            Moving();
        }
    }
    void Moving()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerStats.Money += value;
        PlayerStats.Kills += 1;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }


    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
