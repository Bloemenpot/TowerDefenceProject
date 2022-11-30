using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class Grenade : MonoBehaviour
{
    public GameObject grenade;
    public float radius = 300f;
    public int cost;
    private bool thrown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Pause();

        if (!GameManager.isPaused)
        {
            GrenadeThrowing();
        }
    }

    public void GrenadeThrowing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }
    }

    public void ThrowGrenade()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (PlayerStats.Money >= cost)
        {
            if (Physics.Raycast(ray, out hit))
            {
                GameObject effectIns = (GameObject)Instantiate(grenade, hit.point, Quaternion.identity);
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                thrown = true;
                foreach (Collider nearbyObject in colliders)
                {
                    //Destroy(GameObject.FindGameObjectsWithTag("Enemy"));
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        GameObject.Destroy(enemy);
                    }
                }
                PlayerStats.Money -= cost;
                Destroy(effectIns, 1f);
            }
        }
        else
        {
            thrown = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (thrown)
        {
            Gizmos.DrawSphere(transform.position, radius);
            Debug.DebugBreak();
        }
    }
}
