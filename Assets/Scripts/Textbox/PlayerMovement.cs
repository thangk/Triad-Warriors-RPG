using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private bool canMove = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Lock the rotation
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);
            transform.Translate(movement * speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("MainMenu");
            SceneTransitioner.transitionToScene("MainMenu");
        }

    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void AllowMovement()
    {
        canMove = true;
    }

    public void BounceBack(Vector3 lastPosition, Quaternion originalRotation)
    {
        // Bounce back to the last position without changing rotation
        transform.position = lastPosition;

        // Restore the original rotation
        transform.rotation = originalRotation;

        // Allow movement again
        AllowMovement();
    }
}
