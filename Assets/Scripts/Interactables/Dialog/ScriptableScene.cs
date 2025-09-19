using UnityEngine;
using System.Collections.Generic;



/*
 * < summary >
 *  This class defining a new scriptable object called scriptable scene, it includes information on a scene
 * </summary>
 */
[CreateAssetMenu(fileName = "ScriptableScene", menuName = "Scriptable Objects/ScriptableScene")]
public class ScriptableScene : ScriptableObject
{
    [SerializeField] public ScriptableCharacter character;
    [SerializeField] public int numberOfActions;
    [SerializeField] public List<Line> lines;
    [SerializeField] public List<Choice> choices;
    [SerializeField] public List<GiveItems> items;
    [SerializeField] public List<FlagOption> flags;
 
    public List<string> actionTypes;
  
}


/*
 * < summary >
 * This class defines a serializable line that's a part of ScriptableScene. It includes line's text, it's place and the place of the next action
 * </summary>
 */
[System.Serializable]
public class Line: DialogInterface
{
    [SerializeField] public string text;
    [SerializeField] public int place;
    [SerializeField] public int next;
 
    public string GetText()
    {
        return text;
    }

    public int GetPlace()
    {
        return place;
    }
}

/*
 * < summary >
 *  This class defines a serializable choice that's a part of ScriptableScene
 * </summary>
 */
[System.Serializable]
public class Choice : DialogInterface
{
    [SerializeField] public string name;
    [SerializeField] public int place;
    [SerializeField] public List<ChoiceOption> options;

    public string GetText()
    {
        return name;
    }
    public int GetPlace()
    {
        return place;
    }
    public int ChoicesSize()
    {
        int i = 0;
        foreach (ChoiceOption option in options)
            i++;
        return i;
    }
    public void HideChoice(int i)
    {
        options[i].avilable = false;
    }

    public void ResetChoices()
    {
        foreach (ChoiceOption option in options)
            option.avilable = true;
    }
}

[System.Serializable]
public class ChoiceOption : Line
{
    [SerializeField] public bool avilable = true;
    [SerializeField] public string conditionType;
    [SerializeField] public string item;
}


/*
 * < summary >
 *  This class is serializable and a part of ScriptableScene. It includes information on what item should be added/deleted from inventory
 * </summary>
 */
[System.Serializable]
public class GiveItems : DialogInterface
{
    [SerializeField] public string name;
    [SerializeField] public int place;
    [SerializeField] public int next;
    [SerializeField] public bool add_delete;

    [SerializeField] public GameObject item;

    public int GetPlace()
    {
        return place;
    }

    public string GetText()
    {
        return name;
    }
}


/*
 * < summary >
 *  This class is serializable and a part of ScriptableScene. It includes information on what dialog flag should be raised
 * </summary>
 */
[System.Serializable]
public class FlagOption: DialogInterface
{
    [SerializeField] public string name;
    [SerializeField] public int place;
    [SerializeField] public int next;
    [SerializeField] public int nextScene;
 //   [SerializeField] public Transform character;

    public int GetPlace()
    {
        return place;
    }

    public string GetText()
    {
        throw new System.NotImplementedException();
    }
}
