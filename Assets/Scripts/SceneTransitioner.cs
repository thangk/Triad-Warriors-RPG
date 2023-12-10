using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    private static SceneTransitioner instance; // Singleton instance
    public static string nextScene;
    public Animator animator; // Made non-static
    public SO_GameStateManager gameStateManager;

    void Awake() {
        if (instance == null) {
            instance = this;
            animator = GetComponent<Animator>();

            DontDestroyOnLoad(this.gameObject);
        } else if (instance != this) {
            Destroy(gameObject); // Destroy duplicate
        }
            gameStateManager.GoToMainMenu();
    }

    public static void TransitionToScene(string sceneName) {
        if (instance != null) {
            instance.animator.SetTrigger("fadeOut");
            SetNextScene(sceneName);
        } else {
            Debug.LogError("No SceneTransitioner instance found!");
        }
    }

    private static void SetNextScene(string sceneName) {
        nextScene = sceneName;
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(nextScene);
    }
}
