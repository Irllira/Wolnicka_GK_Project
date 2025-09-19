using UnityEngine;
using System.Collections.Generic;


/*
 * <summary>
 * This class is placed in a game object to signify it is a character
 * </summary>
 */
public class Character : MonoBehaviour, InteractionInterface
{
    [SerializeField] private ScriptableCharacter scriptableObject;
    [SerializeField] private string interactText;
    [SerializeField] private List<Scene> scenes;
    private int CurrentScene = 0;


    public string GetName()
    {
        return scriptableObject.characterName;
    }
    public string GetHello()
    {
        Debug.Log(scriptableObject.hello); 
        return scriptableObject.hello;
    }

    public void Interact()
    {
        return;
    }

    public Scene GetScene()
    {

        if(CurrentScene<0|| CurrentScene>scenes.Count)
            return null;

        return scenes[CurrentScene];

    }

    public string GetText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public bool CanInteract(ItemsManager inventory)
    {
        return true;
    }

    public void NormalNextScene()
    {
        CurrentScene=scenes[CurrentScene].toBePlayedNext;
    }
    public void SetNextScene(int i)
    {
        CurrentScene = i;
    }
}


/*
 * <summary>
 * This class is defining a scene, it is serializable and used in Character class 
 * </summary>
 */

[System.Serializable]
public class Scene
{
    public string SceneName;
    public ScriptableScene sceneScript;
    public int toBePlayedNext;

 
    public void setActionTypes()
    {
        SetNumberOfActions();

     //   if (sceneScript.actionTypes.Count == sceneScript.numberOfActions)
       //     return;

        sceneScript.actionTypes.Clear();
        for (int i = 0; i < sceneScript.numberOfActions; i++)
        {
            foreach (Line line in sceneScript.lines)
            {
                if (line.place == i)
                {
                    sceneScript.actionTypes.Add("Line");
                    break;
                }
            }
            foreach (Choice choice in sceneScript.choices)
            {
                if (choice.place == i)
                {
                    sceneScript.actionTypes.Add("Choice");
                    break;
                }
            }
            foreach (GiveItems item in sceneScript.items)
            {
                if (item.place == i)
                {
                    sceneScript.actionTypes.Add("Item");
                    break;
                }
            }
            foreach (FlagOption item in sceneScript.flags)
            {
                if (item.place == i)
                {
                    sceneScript.actionTypes.Add("Other");
                    break;
                }
            }
        }
    }
   
    public string CheckActionType(int i)
    {
        return sceneScript.actionTypes[i];
    }
    
    public void playScene()
    {
        foreach(Line line in sceneScript.lines)
        {
            Debug.Log(line.text);
        }
    }

    List<Line> GetLines()
    {
        return sceneScript.lines;
    }

    public int GetSize()
    {
        return sceneScript.numberOfActions;
    }

    public ScriptableScene GetScene()
    {
        return sceneScript;
    }

    public Line GetLine(int i)
    {
        foreach (Line line in sceneScript.lines)
        {
            if (i == line.GetPlace())
                return line;
        }
        return null;
    }
    public Choice GetChoice(int i)
    {
        foreach (Choice choice in sceneScript.choices)
        {
            if (i == choice.GetPlace())
                return choice;
        }
        return null;
    }

    public FlagOption GetOther(int i)
    {
        foreach (FlagOption other in sceneScript.flags)
        {
            if (i == other.GetPlace())
                return other;
        }
        return null;
    }

    private void SetNumberOfActions()
    {
        int i = 0;
        foreach (Line line in sceneScript.lines)
        {
            i++;
        }
        foreach (Choice choice in sceneScript.choices)
        {
            i++;
        }
        foreach (GiveItems item in sceneScript.items)
        {
            i++;
        }
        foreach (FlagOption other in sceneScript.flags)
        {
            i++;
        }
        sceneScript.numberOfActions = i;
    }

   

}
