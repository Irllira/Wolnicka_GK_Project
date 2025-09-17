using UnityEngine;
using TMPro;
public class GeneralUI : MonoBehaviour
{
    [SerializeField] protected GameObject containerObject;
   // [SerializeField] protected TextMeshPro textMeshInteraction;
    protected void Show()
    {
        containerObject.SetActive(true);
    }

    protected void Hide()
    {
        containerObject.SetActive(false);
    }
}
