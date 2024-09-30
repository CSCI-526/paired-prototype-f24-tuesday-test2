using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject target;
    public float speed = 10.0f;
    public bool isPrefab = true;
    // Start is called before the first frame update
    void Start()
    {
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
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        // Move the bullet towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the bullet hits the target, destroy the bullet and the target
        if (collision.gameObject == target)
        {
            Destroy(gameObject);
            target.GetComponent<EnemyController>().health--;
            // change the color of the target based on the health
            if (target.GetComponent<EnemyController>().health == 2)
            {
                target.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else if (target.GetComponent<EnemyController>().health == 1)
            {
                target.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (target.GetComponent<EnemyController>().health == 0)
            {
                Destroy(target);
                // add gold to the player
                GameObject.Find("Money").GetComponent<GoldUpdater>().gold += target.GetComponent<EnemyController>().reward;
            }
        }
    }
}
