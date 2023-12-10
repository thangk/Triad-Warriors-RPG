using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class NewProfileNextButton : MonoBehaviour
{
    // initilize a scriptable object with a string profileName
    public SO_CurrentPlayer currentPlayer;

    // take a text input from the user, disable this next button at start and keep validating the input until it is valid, then enable the next button

     public TMP_InputField inputField; 
    public Button nextButton;
    private ColorBlock buttonColors;

    // disabled colors is 255, 255, 255, 150
    private Color disabledImageColor = new Color(150f, 150f, 150f, 100f);
    private Color enabledImageColor = new Color(0, 0, 0, 1f);

    void Start()
    {
        inputField.onValueChanged.AddListener(delegate { ValidateInput(inputField.text); });
        buttonColors = nextButton.colors;
        nextButton.interactable = false;
        SetButtonState(false); // Set initial state to disabled
    }

    void ValidateInput(string input)
    {
        bool isValid = Regex.IsMatch(input, "^[A-Za-z0-9 ]{4,12}$"); // 4-12 characters, alphanumeric and spaces only

        SetButtonState(isValid);
    }

    void SetButtonState(bool isEnabled)
    {
        ColorBlock currentColors = buttonColors;
        nextButton.colors = currentColors;

        if (isEnabled) {
            nextButton.interactable = true;
            nextButton.image.color = enabledImageColor;
        } else {
            nextButton.interactable = false;
            nextButton.image.color = disabledImageColor;
        }

    }

    public void OnClick()
    {
        // Update profileName in scriptableObject
        currentPlayer.profileName = inputField.text;

        // Transition to character selection scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelection");

        Debug.Log("Profile name is: " + currentPlayer.profileName);
    }
}
