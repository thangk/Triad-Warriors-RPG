using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private bool isPlayerInTrigger = true; // This will keep track of the player's presence within the trigger

    private void Update()
    {
        // Check if the left mouse button is pressed and the player is inside the trigger
        if (isPlayerInTrigger && Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            Debug.Log("Left mouse button clicked");
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area");
            isPlayerInTrigger = true; // Set this to true when the player enters the trigger area
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger area");
            isPlayerInTrigger = false; // Set this to false when the player leaves the trigger area
        }
    }
}
