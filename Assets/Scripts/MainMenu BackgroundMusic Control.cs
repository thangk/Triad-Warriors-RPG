using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackgroundMusicControl : MonoBehaviour
{

    private AudioSource audioSource;
    private static MainMenuBackgroundMusicControl instance = null;
    public static MainMenuBackgroundMusicControl Instance {
        get { return instance; }
    }

    // don't destroy on load
    void Awake() {
        // if there is no instance, let this be the instance
        if (instance == null) {
            instance = this;
        }
        // if there is an instance and it is not this, destroy this
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;

        StartCoroutine(Fade(true, audioSource, 3f, 1f));
        StartCoroutine(Fade(false, audioSource, 3f, 0f));
    }

    public IEnumerator Fade(bool fadeIn, AudioSource audioSource, float duration, float targetVolume)
    {
        // calculate length of audio clip in seconds
        if (!fadeIn) {
            double length = (double) audioSource.clip.samples / audioSource.clip.frequency;
            yield return new WaitForSecondsRealtime((float) length - duration);
        }

        float currentTime = 0;
        float startVolume = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }
}
