using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    private Vector3 lastPosition; // Store the position right before the collision
    private Quaternion originalRotation; // Store the original rotation

    void Start()
    {
        // Get the PlayerMovement component attached to the same GameObject
        playerMovement = GetComponent<PlayerMovement>();

        // Initialize lastPosition with the initial position of the player
        lastPosition = transform.position;

        // Store the original rotation
        originalRotation = transform.rotation;
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
    }

    void FixedUpdate()
    {
        // Update lastPosition in FixedUpdate to ensure it reflects the player's position right before the next physics update
        lastPosition = transform.position;
    }
}
