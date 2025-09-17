using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ScriptableScene", menuName = "Scriptable Objects/ScriptableScene")]
public class ScriptableScene : ScriptableObject
{
    [SerializeField] public ScriptableCharacter character;
    [SerializeField] public int numberOfActions;
    [SerializeField] public List<Line> lines;
    [SerializeField] public List<Choice> choices;
    [SerializeField] public List<GiveItems> items;
    [SerializeField] public List<OtherDialogOption> flags;
 //[SerializeField] public List<DialogInterface> wholeList; 
    public List<string> actionTypes;




 //   [ContextMenu("AddLine")]
   // public void AddLine()
   // {
      //  lines.Add(new Line(" "));
   // }

  
}

[System.Serializable]
public class Line: DialogInterface
{
    [SerializeField] public string text;
    [SerializeField] public int place;
    [SerializeField] public int next;
  
    // InteractionInterface next;  //???
    public string GetText()
    {
        return text;
    }

    //public Line(string s)
    //{
      //  text = s;
    //}
    public int GetPlace()
    {
        return place;
    }
}

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
[System.Serializable]
public class ChoiceOption : Line
{
    [SerializeField] public bool avilable = true;
    [SerializeField] public string conditionType;
    [SerializeField] public string item;
}

[System.Serializable]
public class OtherDialogOption: DialogInterface
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
