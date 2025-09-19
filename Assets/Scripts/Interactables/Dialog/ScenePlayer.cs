using UnityEngine;


/*
 * <summary>
 * This class is controlling a playing scene
 * </summary>
 */
public class ScenePlayer : MonoBehaviour
{
    [SerializeReference] private DialogUI dialogUI;
    private bool finished = false;
    private int curentAction = 0;
    private Scene scenePlaying = null;
    private bool choiceBeingMade = false;
    private int choiceOption = -1;
    private Choice curentChoice = null;
    private ItemsManager playerInventory;

    private Character character = null;

    private void Update()
    {
        if (scenePlaying == null)
            return;
    }

    // This method is responsible for setting up a scene when it first starts playing
    public void SetScene(Scene scene, ItemsManager inventory, Character chara, DialogFlagController dfc)
    {
        character = chara;
        playerInventory = inventory;
        scenePlaying = scene;
        scenePlaying.setActionTypes();
     
        curentAction = 0;
        finished = false;
        dialogUI.StartScene();
        PlayNext(dfc);
        

    }

    //This method is responsible for playing out a current action and returns information on whether or not there is a next action
    public bool PlayNext(DialogFlagController dfc)
    {
        string s = "";
        if (scenePlaying == null || finished == true)
            return false;
        if (curentAction == 0)
        {
            dialogUI.ShowHelpGeneral();
        }
        else
        {
            dialogUI.HideHelpGeneral();
        }


        switch (scenePlaying.CheckActionType(curentAction))
        {
            case "Line":

                PlayNpcsLine();

                curentAction = scenePlaying.GetLine(curentAction).next;
                if (curentAction == 0)
                    finished = true;
                break;

            case "Choice":
                if (choiceBeingMade == false || choiceOption < 0)
                {
                    curentChoice = scenePlaying.GetChoice(curentAction);
                    s = "ChoiceTime" + choiceOption;
                    CheckChoices();
                    // dodæ ¿e jeœli nie jest wybrany wybór wyœwietliæ wiadomoœæ ¿e góra dó³
                    dialogUI.DialogOptions(curentChoice, -1);
                    choiceBeingMade = true;
                    Debug.Log(s);
                    dialogUI.ShowHelpChoice();
                    //   currentline = 4;
                    //   choiceBeingMade = true;
                }
                else
                {
                    s = "Choice was made: " + choiceOption;
                    Debug.Log(s);
                    Debug.Log(curentChoice.options[choiceOption]);
                    curentAction = curentChoice.options[choiceOption].next;
                    EndChoice();
                    if (curentAction != 0)
                    {
                        return PlayNext(dfc);
                    }
                    else
                    {
                        return false;
                    }
                }
                break;
            case "Item":
                break;    
              //  return PlayNext(dfc);

            case "Other":

                FlagOption flag = GetFlag();
                dfc.ChangeFlag(flag.name);

                curentAction = scenePlaying.GetOther(curentAction).next;
                if (curentAction == 0)
                {
                    finished = true;
                    //return true;
                }

                return PlayNext(dfc);
        }


        /*if (scenePlaying.CheckActionType(curentAction) == "Line")
        {
            PlayNpcsLine();

            curentAction = scenePlaying.GetLine(curentAction).next;
            if (curentAction == 0)
                finished = true; ;
        }
        else
        {
            if (choiceBeingMade == false)
            {
                curentChoice = scenePlaying.GetChoice(curentAction);
                s = "ChoiceTime" + choiceOption;
                // dodæ ¿e jeœli nie jest wybrany wybór wyœwietliæ wiadomoœæ ¿e góra dó³
                dialogUI.DialogOptions(curentChoice,-1);
                choiceBeingMade = true;
                Debug.Log(s);
                dialogUI.ShowHelpChoice();
                //   currentline = 4;
                //   choiceBeingMade = true;
            }
            else
            {
                s = "Choice was made: " + choiceOption;
                Debug.Log(s);
                Debug.Log(curentChoice.options[choiceOption]);
                curentAction = curentChoice.options[choiceOption].next;
                EndChoice();
                if (curentAction != 0)
                {
                    return PlayNext();
                }
                else
                {
                    return false;
                }
            }

        }*/

        return true;
    }

    
    // This method is responsible for giving information on what item should be given based on the currentAction
    public GiveItems GetItem()
    {
        //Item it;
        
        foreach (GiveItems item in scenePlaying.sceneScript.items)
        {
            if (item.place == curentAction)
            {
               // if(item.add_delete)
               // 
                curentAction=item.next;

                if (curentAction == 0)
                    finished = true;
                //Debug.Log("Axe added");
                //        it.scriptableObject= item.item;
                return item;
                
            }
        }
        return null;
    }


    // This method is responsible for giving information on what flag should be given based on the currentAction
    public FlagOption GetFlag()
    {
        foreach (FlagOption flag in scenePlaying.sceneScript.flags)
        {
            if (flag.place == curentAction)
            {
                // if(item.add_delete)
                // 
          //      curentAction = flag.next;
                //Debug.Log("Axe added");
                //        it.scriptableObject= item.item;
                return flag;

            }
        }
        return null;
    }

    // This method is responsible for playing an NPC's dialog
    private void PlayNpcsLine()
    {
        string s = "";
        if (scenePlaying.GetLine(curentAction) != null)
        {
            s = scenePlaying.GetLine(curentAction).text;
            dialogUI.NpcSpeaking(s);
        }
        else
        {
            HideScene();
        }
    }


    // This method is responsible for "cleaning up" the scene when it's over
    public void HideScene()
    {
        character.NormalNextScene();   
        dialogUI.HideScene();
        scenePlaying = null;
        finished = true;
        curentAction = 0;
    }

    // This method is responsible for "cleaning up" dialog options after the choice is made
    private void EndChoice()
    {
        curentChoice = null;
        choiceBeingMade = false;
        choiceOption = -1;
        dialogUI.ClearChoice();
    }

    // This method is returns information on wheter or no the choice is being made
    public bool IsChoiceActive()
    {
        return choiceBeingMade;
    }

    //This methos is responsible for controlling what dialog option is curently chosen
    public void SetChoice(bool up)
    {
        if (up)
        {
            choiceOption = choiceOption - 1;
        }
        else
        {
            choiceOption = choiceOption + 1;
        }

        if (choiceOption < 0)
            choiceOption = curentChoice.ChoicesSize() - 1;
        if (choiceOption > curentChoice.ChoicesSize() - 1)
            choiceOption = 0;


        if(curentChoice.options[choiceOption].avilable==false)
        {

            if (up)
            {
                choiceOption = choiceOption - 1;
            }
            else
            {
                choiceOption = choiceOption + 1;
            }

            if (choiceOption < 0)
                choiceOption = curentChoice.ChoicesSize() - 1;
            if (choiceOption > curentChoice.ChoicesSize() - 1)
                choiceOption = 0;
        }

        dialogUI.HideHelpChoice();
        //  dialogUI.ChoiceFrameSet(choiceOption);
        dialogUI.DialogOptions(curentChoice, choiceOption);
    }


    // This method returns information on what is the type of the curent action
    public string GetCurrentType()
    {
        return scenePlaying.CheckActionType(curentAction);
    }

    // This method returns information on what character the scene is attached to
    public ScriptableCharacter GetCharacter()
    {
        return scenePlaying.sceneScript.character;
    }

    // This method is responsible for checing if the dialog option is avaliable
    private void CheckChoices()
    {
        curentChoice.ResetChoices();
        int i = 0;
        foreach(ChoiceOption choice in curentChoice.options)
        {
            if(choice.conditionType!=null && choice.conditionType != " " && choice.conditionType != "none")
            {
                if(choice.conditionType=="ItemTrue")
                {
                    if(!playerInventory.CheckInventory(choice.item))
                    {
                        curentChoice.HideChoice(i);
                    }
                }
                if (choice.conditionType == "ItemFalse")
                {
                    if (playerInventory.CheckInventory(choice.item))
                    {
                        curentChoice.HideChoice(i);
                    }
                }
            }
           
            i++;
        }
    }
}


