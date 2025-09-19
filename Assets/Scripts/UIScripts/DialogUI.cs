using UnityEngine;
using UnityEngine.UI;

using TMPro;


/*
 <summary>
    This class is responsible for controling the users interface during dialog scenes
 </summary>
 */

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
        characterContainer = containerObject.transform.Find("CharacterDialogContainer");
        PlayerDialogUI = containerObject.transform.Find("PlayerDialogUI");
        dialogOptionContainer = PlayerDialogUI.Find("DialogOptionsContainer");
        dialogOptionTamplate = dialogOptionContainer.Find("DialogOptionTamplate");

        helpChoice = PlayerDialogUI.Find("HelpContainer");
        helpGeneral = containerObject.transform.Find("HelpContainer");
    }

    //This method sets up players dialog options, including seting up a frame around a curently chosen option
    public void DialogOptions(Choice choice,int choiceOption)
    {
        ClearChoice();
        int x = 0;
        int y = 0;
        int z = 0;
        float optionSize = 55f;

        Image frame;

        TextMeshProUGUI text;

        foreach (ChoiceOption option in choice.options)
        {
            if (option.avilable == true)
            {
                RectTransform dialogOptionSlot = Instantiate(dialogOptionTamplate, dialogOptionContainer).GetComponent<RectTransform>();
                dialogOptionSlot.gameObject.SetActive(true);

                dialogOptionSlot.anchoredPosition = new Vector2(x * optionSize, -y * optionSize);              //position

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
 
    //This method shows NPC's dialog
    public void NpcSpeaking(string line)
    {   
        npcDialogLine = characterContainer.Find("Text").GetComponent<TextMeshProUGUI>();
        npcDialogLine.text = line;

        characterDialogContainer.SetActive(true);
        Debug.Log(npcDialogLine.text);

    }

    //This method deletes choices, it is called after the choice was made
    public void ClearChoice()
    {
        foreach (Transform child in dialogOptionContainer)
        {
            if (child != dialogOptionTamplate)
                Destroy(child.gameObject);
        }
    }

    //This method shows dialog UI
    public void StartScene()
    {
        Show();
    }

    //This method hides dialog UI
    public void HideScene()
    {
        characterDialogContainer.SetActive(false);
        containerObject.SetActive(false);
    }


    //This method hides information on how to operate dialog
    public void ShowHelpGeneral()
    {
        helpGeneral.gameObject.SetActive(true);
    }

    //This method hidesinformation on how to operate dialog
    public void HideHelpGeneral()
    {
        helpGeneral.gameObject.SetActive(false);
    }

    //This method shows information on how to operate dialog choices
    public void ShowHelpChoice()
    {
        helpChoice.gameObject.SetActive(true);
    }

   //This method hides information on how to operate dialog choices
    public void HideHelpChoice()
    {
        helpChoice.gameObject.SetActive(false);
    }

}