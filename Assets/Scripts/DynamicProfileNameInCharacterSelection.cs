using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DynamicProfileNameInCharacterSelection : MonoBehaviour
{

    public TextMeshProUGUI profileNameText;
    public SO_CurrentPlayer currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        profileNameText.text = profileNameText.text + " " + currentPlayer.profileName;   
    }
}
