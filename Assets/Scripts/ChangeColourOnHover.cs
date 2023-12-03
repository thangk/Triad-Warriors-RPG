using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColourOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    private Color hoverColour = new Color(1f, 1f, 1f, 200f);
    private Color normalColour = new Color(0.25f, 0.25f, 0.25f, 200f);
    private float transitionTime = 0.5f;
    // Start is called before the first frame update

    void Start()
    {
        image = GetComponent<Image>();
        image.color = normalColour;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TransitionColour(image, hoverColour, transitionTime));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TransitionColour(image, normalColour, transitionTime));
    }

    IEnumerator TransitionColour(Image image, Color targetColour, float duration)
    {
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
