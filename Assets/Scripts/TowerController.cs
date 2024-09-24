using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public bool isPrefab = true;
    private float bulletInterval = 1.0f;
    private float lastTime = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isPrefab)
        {
            return;
        }
        // Every 1 second, spawn a bullet
        if (Time.time - lastTime > bulletInterval)
        {
            lastTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<BulletController>().isPrefab = false;
            bullet.GetComponent<BulletController>().target = GameObject.Find("Enemy");
        }
    }
}
