using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class Turret : Actor
{

    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float turnSpeed = 10f;

    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private List<GameObject> enemies;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        enemies = new List<GameObject>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Pause();

        if (!GameManager.isPaused)
        {
            TurretTurning();
        }
    }
    private bool IsNull(GameObject go)
    {
        return go == null;
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        enemies.RemoveAll(IsNull);

        for (int i = 0; i < enemies.Count; i++)
        {

            float distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy < range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemies[i];
            }
            else
            {
                target = null;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 8:
                enemies.Add(other.gameObject);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 8:
                enemies.Remove(other.gameObject);
                break;
            default:
                break;
        }
    }
    void TurretTurning()
    {
        if (target == null)
            return;

        //Turning + Smooth transision
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        //Wireframe range view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
