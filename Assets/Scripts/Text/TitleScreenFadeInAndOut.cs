using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleScreenFadeInAndOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float fadeDuration = 1f;

    public TextMeshProUGUI textMesh;
    private bool fadingIn = true;
    private bool isBeingHovered = false;
    public AudioSource clicktostartAudio;

    [Header("COLOR OPTIONS")]
    public Color hoverColor;
    public Color originalColor;


    void Start()
    {
        originalColor = textMesh.color;
        textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh == null)
        {
            return;
        }

        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        while (true)
        {
            if (fadingIn)
            {
                yield return StartCoroutine(FadeText(0f, 1f, fadeDuration));
            }
            else
            {
                yield return StartCoroutine(FadeText(1f, 0f, fadeDuration));
            }

            fadingIn = !fadingIn;
        }
    }

    IEnumerator FadeText(float startAlpha, float targetAlpha, float duration)
    {
        float currentTime = 0f;
        Color startColor = textMesh.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        while (currentTime < duration)
        {
            if (isBeingHovered)
            {
                currentTime += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
                textMesh.color = new Color(hoverColor.r, hoverColor.g, hoverColor.b, alpha);
                yield return null;
            }
            else
            {
                currentTime += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
                textMesh.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }
        }

        

        textMesh.color = targetColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //textMesh.color = hoverColor;
        isBeingHovered = true;
        textMesh.color = Color.black;
        clicktostartAudio.Play();
        
        

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isBeingHovered = false;
        textMesh.color = originalColor;
    }
}
