using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostedSpeed = 10f;
    public float boostDuration = 5f;
    public float cooldownDuration = 10f;

    private bool isBoosting = false;
    private bool isOnCooldown = false;

    private float originalSpeed;
    private float boostEndTime;
    private float cooldownEndTime;

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    void Start()
    {
        // Get the PlayerMovement component attached to the same GameObject
        playerMovement = GetComponent<PlayerMovement>();

        // Store the original speed
        originalSpeed = playerMovement.speed;
    }

    void Update()
    {
        // Check for the "E" key press to activate the speed boost
        if (Input.GetKeyDown(KeyCode.E) && !isBoosting && !isOnCooldown)
        {
            StartSpeedBoost();
        }

        // Check if the boost duration has expired
        if (isBoosting && Time.time >= boostEndTime)
        {
            EndSpeedBoost();
        }

        // Check if the cooldown period has elapsed
        if (isOnCooldown && Time.time >= cooldownEndTime)
        {
            isOnCooldown = false;
        }
    }

    void StartSpeedBoost()
    {
        // Apply the boosted speed
        playerMovement.speed = boostedSpeed;

        // Set the flag to indicate that the player is currently boosting
        isBoosting = true;

        // Calculate the time when the boost will end
        boostEndTime = Time.time + boostDuration;

        // Set the cooldown flag and calculate the time when the cooldown will end
        isOnCooldown = true;
        cooldownEndTime = Time.time + cooldownDuration;

        // You can add additional actions or visual feedback here when the boost starts
        Debug.Log("Speed Boost Activated!");
    }

    void EndSpeedBoost()
    {
        // Reset the speed to the original speed
        playerMovement.speed = originalSpeed;

        // Reset the flag
        isBoosting = false;

        // You can add additional actions or visual feedback here when the boost ends
        Debug.Log("Speed Boost Ended!");
    }
}
