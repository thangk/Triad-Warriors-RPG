using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColourOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    private GameObject story;
    private Color hoverColour = new Color(1f, 1f, 1f, 200f);
    private Color normalColour = new Color(0.25f, 0.25f, 0.25f, 200f);
    private float transitionTime = 0.5f;
    // Start is called before the first frame update

    void Start()
    {
        image = GetComponent<Image>();
        image.color = normalColour;

        story = GameObject.Find(image.gameObject.name + "Story");
        if (story != null) {
            story.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TransitionColour(image, true, hoverColour, transitionTime));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TransitionColour(image, false, normalColour, transitionTime));
    }

    IEnumerator TransitionColour(Image image, bool mode, Color targetColour, float duration)
    {

        if (story != null) {
            story.SetActive(mode);
        }

        float time = 0;
        Color startColour = image.color;
        while (time < duration)
        {
            image.color = Color.Lerp(startColour, targetColour, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        image.color = targetColour;
    }
}
