using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    private float spaceInput;
    public GameObject towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        spaceInput = Input.GetAxis("Jump");
        // Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Move left and right
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        // Create an object
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tower = Instantiate(towerPrefab, transform.position, transform.rotation);
            tower.GetComponent<TowerController>().isPrefab = false;
        }
    }
}
