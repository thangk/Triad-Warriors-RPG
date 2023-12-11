using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    private Vector3 lastPosition; // Store the position right before the collision
    private Quaternion originalRotation; // Store the original rotation

    public Tilemap itemsTilemap; // Reference to the "Items" Tilemap
    private TilemapRenderer tilemapRenderer; // Reference to the TilemapRenderer component

    void Start()
    {
        // Get the PlayerMovement component attached to the same GameObject
        playerMovement = GetComponent<PlayerMovement>();

        // Initialize lastPosition with the initial position of the player
        lastPosition = transform.position;

        // Store the original rotation
        originalRotation = transform.rotation;

        // Get the TilemapRenderer component from the "Items" Tilemap
        tilemapRenderer = itemsTilemap.GetComponent<TilemapRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            // Handle collision with the border here
            Debug.Log("Player collided with the border!");

            // Bounce back to the last position without changing rotation
            if (playerMovement != null)
            {
                playerMovement.BounceBack(lastPosition, originalRotation);
            }

            // You can add additional actions or logic here
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Player collided with the potion!");

            // Disable the TilemapRenderer component to hide the "Items" Tilemap
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (tilemapRenderer != null)
                {
                    tilemapRenderer.enabled = false;
                }
            }

            // You can add additional actions or logic here
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Player collided with the Door!");

            SceneManager.LoadScene("Area 1");

            // You can add additional actions or logic here
        }

        if (collision.gameObject.CompareTag("Door2"))
        {
            Debug.Log("Player collided with the Door!");

            SceneManager.LoadScene("Area 2");

            // You can add additional actions or logic here
        }
    }

    void FixedUpdate()
    {
        // Update lastPosition in FixedUpdate to ensure it reflects the player's position right before the next physics update
        lastPosition = transform.position;
    }
}
