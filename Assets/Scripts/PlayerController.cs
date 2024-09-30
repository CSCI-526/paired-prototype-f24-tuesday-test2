using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float jumpForce = 150.0f;
    private bool isGrounded = true;
    private float horizontalInput;
    private float forwardInput;
    private float spaceInput;
    private Rigidbody rb;
    public GameObject towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Create an object
        if (Input.GetKeyDown(KeyCode.LeftShift))
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Get the forward direction of the camera (ignoring the Y-axis to keep movement horizontal)
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;  // Ignore the Y-axis for movement
        forward.Normalize();

        // Get the right direction of the camera
        Vector3 right = Camera.main.transform.right;
        right.y = 0;  // Ignore the Y-axis for movement
        right.Normalize();

        // Combine forward and right input based on player input
        Vector3 direction = forward * forwardInput + right * horizontalInput;

        // Apply the velocity to the Rigidbody (keeping the existing Y velocity for jumping/gravity)
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
