using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public GameObject Base;
    public int cost = 100;
    public float range = 10;
    public bool isPrefab = true;
    public float bulletInterval = 1.0f;
    private float lastTime = -999;
    void Start()
    {
        // set the range indicator of the tower to the range
        transform.GetChild(0).transform.localScale = new Vector3(range, 0.1f, range);
    }

    public GameObject GetEnemyClosestToBaseInRange()
    {
        // Get all enemies by tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;  // Set an initial large distance
        Vector3 currentPosition = transform.position;

        // Loop through all enemies to find the nearest one
        foreach (GameObject enemy in enemies)
        {
            // check if enemy is a prefab
            if (enemy.GetComponent<EnemyController>().isPrefab)
            {
                continue;
            }
            // check if enemy is in range of the tower
            if (Vector3.Distance(currentPosition, enemy.transform.position) > range)
            {
                continue;
            }
            float distance = Vector3.Distance(Base.transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;  // Return the nearest enemy
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (isPrefab)
        {
            return;
        }
        // Every 1 second, spawn a bullet
        if (Time.time - lastTime > bulletInterval)
        {
            GameObject enemy = GetEnemyClosestToBaseInRange();
            if (enemy == null)
            {
                return;
            }
            lastTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<BulletController>().isPrefab = false;
            bullet.GetComponent<BulletController>().target = enemy;
        }
    }
}
