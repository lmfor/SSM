using UnityEngine;
using TMPro;
using System.Collections;

public class ButtonFadeInAndOut : MonoBehaviour
{
    public float fadeDuration = 1f;

    private TextMeshProUGUI buttonText;
    private bool fadingIn = true;

    void Start()
    {
        buttonText = GetComponent<TextMeshProUGUI>();
        if (buttonText == null)
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
        Color startColor = buttonText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            buttonText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        buttonText.color = targetColor;
    }
}
