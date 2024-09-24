using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject target;
    private float speed = 10.0f;
    public bool isPrefab = true;
    // Start is called before the first frame update
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
            Destroy(target);
            Destroy(gameObject);
        }
    }
}
