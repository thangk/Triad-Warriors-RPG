using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneTransitioner.transitionToScene("CharacterSelection");
        //SceneTransitioner.transitionToScene("Freeroam");
    }

    public void GoToMainMenu()
    {
        SceneTransitioner.transitionToScene("MainMenu");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
