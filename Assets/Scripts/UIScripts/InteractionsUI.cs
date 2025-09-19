using UnityEngine;
using TMPro;


/*
 <summary>
    This class is responsible for controling the interaction interface
 </summary>
 */
public class InteractionsUI : GeneralUI
{
   // [SerializeField] private GameObject containerObject;
    [SerializeField] private Player playerInteraction;
    [SerializeField] private TextMeshProUGUI textMeshInteraction;


    private void Update()
    {
        if (playerInteraction.GetInteraction() != null)
        {
            Show(playerInteraction.GetInteraction());
        }else
        {
            Hide();
        }
    }
    private void Show(InteractionInterface interactable)
    {
        containerObject.SetActive(true);
        
        if(interactable.GetText()!=null)
            textMeshInteraction.text = interactable.GetText();

    }

   /* private void Hide()
    {
        containerObject.SetActive(false);
    }
   */
}
