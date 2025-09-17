using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class DialogUI : GeneralUI
{
    private ItemsManager playerInventory;
    private Character character;


    [SerializeField] private GameObject characterDialogContainer;


    private TextMeshProUGUI npcDialogLine;
    private Transform characterContainer;
    private Transform PlayerDialogUI;
    private Transform dialogOptionContainer;
    private Transform dialogOptionTamplate;

    private Transform helpGeneral;
    private Transform helpChoice;

    private void Awake()
    {
        //Transform buff = transform.Find("DialogWindowContainer");

        characterContainer = containerObject.transform.Find("CharacterDialogContainer");
        PlayerDialogUI = containerObject.transform.Find("PlayerDialogUI");
        dialogOptionContainer = PlayerDialogUI.Find("DialogOptionsContainer");
        dialogOptionTamplate = dialogOptionContainer.Find("DialogOptionTamplate");

        helpChoice = PlayerDialogUI.Find("HelpContainer");
        helpGeneral = containerObject.transform.Find("HelpContainer");
    }

    public void DialogOptions(Choice choice,int choiceOption)
    {
        ClearChoice();
        int x = 0;
        int y = 0;
        int z = 0;
        float optionSize = 55f;

        Image background;
      //  background = PlayerDialogUI.Find("Bacground").GetComponent<Image>();
        //   background.SetNativeSize();
        Image frame;

        TextMeshProUGUI text;

        foreach (ChoiceOption option in choice.options)
        {
            if (option.avilable == true)
            {
                RectTransform dialogOptionSlot = Instantiate(dialogOptionTamplate, dialogOptionContainer).GetComponent<RectTransform>();
                dialogOptionSlot.gameObject.SetActive(true);

                dialogOptionSlot.anchoredPosition = new Vector2(x * optionSize, -y * optionSize);              //position

                //icon = dialogOptionSlot.Find("Background").Find("Icon").GetComponent<Image>();             //icon
                //    icon.sprite = itemSlot.GetSprite();



                text = dialogOptionSlot.Find("ChoiceText").GetComponent<TextMeshProUGUI>();   //text
                text.text = option.text;
                frame = dialogOptionSlot.Find("Frame").GetComponent<Image>();                                 //currently chosen item
                if (choiceOption == z)
                {
                    frame.gameObject.SetActive(true);
                }
                else
                {

                    frame.gameObject.SetActive(false);
                }
                y++;
            }
            z++;
        }

    }
    public void ChoiceFrameSet(int choiceOption)
    {
        //set a frame around the right choice
    }
    public void NpcSpeaking(string line)
    {

        
        npcDialogLine = characterContainer.Find("Text").GetComponent<TextMeshProUGUI>();
        npcDialogLine.text = line;

        characterDialogContainer.SetActive(true);
        Debug.Log(npcDialogLine.text);

    }


    public void ClearChoice()
    {
        foreach (Transform child in dialogOptionContainer)
        {
            if (child != dialogOptionTamplate)
                Destroy(child.gameObject);
        }
    }

    private void Show(InteractionInterface interactable)
    {
        containerObject.SetActive(true);

        //   if (interactable.GetText() != null)
        //     textMeshInteraction.text = interactable.GetText();
    }

    public void StartScene()
    {
        Show();
    }    
    public void HideScene()
    {
        characterDialogContainer.SetActive(false);
        containerObject.SetActive(false);
    }

    public void ShowHelpGeneral()
    {
        helpGeneral.gameObject.SetActive(true);
    }
    public void HideHelpGeneral()
    {

        helpGeneral.gameObject.SetActive(false);
    }
    public void ShowHelpChoice()
    {
        helpChoice.gameObject.SetActive(true);
    }

    public void HideHelpChoice()
    {
        helpChoice.gameObject.SetActive(false);
    }

    private void SetChoiceBacground(Choice choice)
    {
        switch (choice.ChoicesSize())
        {
            case 1:

                break;
            case 2:
                break;

            default:
                break;

        }

    }
}