using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    private static string nextScene;
    public static Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
    }

    public static void transitionToScene(string sceneName) {
        animator.SetTrigger("fadeOut");
        setNextScene(sceneName);
    }

    public static void setNextScene(string sceneName) {
        nextScene = sceneName;
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(nextScene);
    }
}
