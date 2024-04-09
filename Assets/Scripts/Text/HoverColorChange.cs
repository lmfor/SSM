using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text textComponent;
    public Color hoverColor;

    private Color originalColor;

    void Start()
    {
        originalColor = textComponent.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textComponent.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textComponent.color = originalColor;
    }
}
