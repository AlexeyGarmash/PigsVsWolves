using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour {

    private Transform target;
    private Turret targetTurret;

    public GameObject particlePrefab;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public string enemyTag;

    public float range = 5f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetTurret = nearestEnemy.GetComponent<Turret>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        Debug.Log("Shoot as wolf");
        GameObject wolfskillGO = (GameObject)Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(wolfskillGO, 2f);
        WolfSkill wolfskill = wolfskillGO.GetComponent<WolfSkill>();

        if (wolfskill != null)
        {
            wolfskill.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
