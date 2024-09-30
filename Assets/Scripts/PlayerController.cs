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
            // check if the player has enough gold
            if (GameObject.Find("Money").GetComponent<GoldUpdater>().gold < towerPrefab.GetComponent<TowerController>().cost)
            {
                // TODO: display a message to the player
                return;
            }
            // spawn a tower slightly right of the player
            GameObject tower = Instantiate(towerPrefab, transform.position + new Vector3(2, 0, 0), transform.rotation);
            tower.GetComponent<TowerController>().isPrefab = false;
            // subtract the cost of the tower from the player's gold
            GameObject.Find("Money").GetComponent<GoldUpdater>().gold -= towerPrefab.GetComponent<TowerController>().cost;
        }
    }
}
