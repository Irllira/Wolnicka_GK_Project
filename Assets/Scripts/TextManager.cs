using UnityEngine;
using TMPro;

public class TextManager: MonoBehaviour
{
    private SpriteRenderer bacgroundSprite;
    private TextMeshPro text;

    public static void Create(Transform parent, Vector3 localPosition, string text)
    {
        Transform bubble = Instantiate(GameAssets.instance.prefabTalkingBubble, parent);
        bubble.localPosition = localPosition;

        bubble.GetComponent<TextManager>().Setup(text);
    }

    private void Awake()
    {
        bacgroundSprite = transform.Find("Background").GetComponent<SpriteRenderer>();
        text = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Setup(string dialog)
    {
        text.SetText(dialog);
        text.ForceMeshUpdate();
        Vector2 buffvector = text.GetRenderedValues(false);
        Vector2 textSize =new Vector2 (buffvector.y,buffvector.x);
        Vector2 margins = new Vector2(0.1f,-3f);
        bacgroundSprite.size = textSize + margins;
    }
}

