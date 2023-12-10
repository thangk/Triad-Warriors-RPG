using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


[CreateAssetMenu(fileName = "SO_GameStateManager", menuName = "ScriptableObjects/SO_GameStateManager", order = 0)]
public class SO_GameStateManager : ScriptableObject {
    
    // look for gameObject named "MainMenuButtons" in the scene and assign it to this variable
    public GameState currentGameState;
    public SO_CurrentPlayer currentPlayer;

    private GameState[] gameObjectsWithSharedScene = new GameState[] {
        GameState.MainMenu,
        GameState.NewGame,
        GameState.LoadGame,
        GameState.Settings,
    };

    // create a key value pair of game state and game object
    private Dictionary<GameState, GameObject> gameStateToGameObject = new Dictionary<GameState, GameObject>();

    void OnEnable() {
    
    
    gameStateToGameObject.Clear(); // Clear existing entries

    foreach (GameState gameState in gameObjectsWithSharedScene) {
        GameObject gameObject = GameObject.Find(gameState.ToString());
        if (gameObject != null) {
            gameStateToGameObject[gameState] = gameObject;
            Debug.Log($"Found GameObject for state: {gameState}");
        } else {
            Debug.LogWarning($"GameObject not found for state: {gameState}");
        }
    }

}


    public void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;

        // switch statement to set the active game object
        switch (currentGameState) {
            case GameState.MainMenu:
                GoToMainMenu();
                break;
            case GameState.NewGame:
                GoToNewGame();
                break;
            case GameState.WarriorSelection:
                GoToWarriorSelection();
                break;
            case GameState.LoadGame:
                SetRestFalse(GameState.LoadGame);
                GoToLoadGame();
                break;
            case GameState.Settings:
                SetRestFalse(GameState.Settings);
                GoToSettings();
                break;
            default: return;
        }
    }

    public void InitialMainMenu() {
        SetRestFalse(GameState.MainMenu);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
        SetRestFalse(GameState.MainMenu);
    }

    public void GoToWarriorSelection() {
        SceneManager.LoadScene("WarriorSelection");
    }

    public void GoToNewGame() {
        SetRestFalse(GameState.NewGame);
    }

    public void GoToLoadGame() {
        SceneManager.LoadScene("LoadGame");
    }

    public void GoToInventory() {
        SceneManager.LoadScene("Inventory");
    }

    public void GoToSettings() {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void SetRestFalse(GameState trueGameState) {
    foreach (KeyValuePair<GameState, GameObject> entry in gameStateToGameObject) {
        // if key is equal to trueGameState, setActive(true)
        if (entry.Key == trueGameState) {
            entry.Value.SetActive(true);
            Debug.Log($"{entry.Key}: true");
        } else {
            entry.Value.SetActive(false);
            Debug.Log($"{entry.Key}: false");
        }
    }
}

}

