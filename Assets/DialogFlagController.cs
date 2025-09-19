using System.Collections.Generic;
using UnityEngine;



/*
 <summary>
    This class is responsible for controling the dialog flags and updating what scene is to be played next based on them
 </summary>
 */
public class DialogFlagController : MonoBehaviour
{
    [SerializeField] public List<Flag> flags;
    [SerializeField] private Transform disappearController;
    
    private DisappearController dc;

    private void Awake()
    {
        dc= disappearController.GetComponent<DisappearController>();
    }

  
    public void RedWolfFlag(Character character)
    {
        if(character.GetName() != "Little Red")
        {
            foreach(Flag fl in flags)
            {
                if (fl.name == "RedCollectingFlowers" && fl.flag == true)
                {
                    ChangeFlag("RedWolf");
                }
                if (fl.name == "RedGonnaGo" && fl.flag == true)
                {
                    ChangeFlag("SafeWithGrandma");
                }
                if((fl.name == "RedScared" || fl.name == "WolfRegular" || fl.name == "WolfScared"
                    || fl.name == "RedGonnaGo" || fl.name == "MomSavedTheDay") && fl.flag==true)
                {
                    dc.disappearWolfRed();
                    return;
                }
            }
        }
    }
    public void UpdateFlags(ItemsManager playerInventory)
    {
        if(playerInventory.GetInventorySize()>=0 && playerInventory.CheckInventory("Food Bascet"))
        {
            foreach(Flag f in flags)
            {
                if (f.name == "MomBasket")
                {
                    f.flag = true;
                    LowerFlags(f);
                }
            }
        }else
        {
            foreach (Flag f in flags)
            {
                if (f.name == "MomBasket")
                    f.flag = false;
            }
        }

        if (playerInventory.GetInventorySize() >= 0 && playerInventory.CheckInventory("BottleCap"))
        {
            foreach (Flag f in flags)
            {
                if (f.name == "BirdPostBread")
                {
                    f.flag = true;
                    LowerFlags(f);
                }
            }
        }
        else
        {
            foreach (Flag f in flags)
            {
                if (f.name == "BirdPostBread")
                    f.flag = false;
            }
        }
    }
    public void ChangeFlag(Flag f)
    {
        foreach (Flag flag in flags)
        {
            if ((flag.character == f.character && flag.Scene == f.Scene)||(flag.name==f.name))
            {
                flag.flag = true;
                LowerFlags(flag);
                return;
            }
                
        }
    }
    public void ChangeFlag(FlagOption f)
    {
        foreach (Flag flag in flags)
        {
            if (flag.name == f.name)
            {
                flag.flag = true;
                LowerFlags(flag);
                return;
            }

        }
    }

    public void ChangeFlag(string flagname)
    {
        foreach (Flag flag in flags)
        {
            if (flag.name == flagname)
            {
                flag.flag = true;
                LowerFlags(flag);
                //return;
            }

        }
    }
    private void LowerFlags(Flag f)
    {
        foreach(Flag flag in flags)
        {
            if (flag.character == f.character && flag.Scene != f.Scene)
                flag.flag = false;
        }
    }
    public void RaiseFlags()
    { 
        foreach(Flag flag in flags)
        {
            if (flag.flag)
            {
                if (flag.character.name != "Birds")
                {
                    Character ch = flag.character.GetComponent<Character>();

                    ch.SetNextScene(flag.Scene);
                }
                else
                {
                    Character ch = new Character();
                    for (int i = 0; i < flag.character.childCount; i++)
                    {
                        ch = flag.character.GetChild(i).GetComponent<Character>();
                        ch.SetNextScene(flag.Scene);
                    }
                     
                }
            }
        }
    }

    public bool CheckFlag(string name)
    {
        foreach (Flag f in flags)
        {
            if (f.name == name)
                return f.flag;
        }
        return false; 
    }
}


[System.Serializable]
public class Flag : DialogInterface
{
    [SerializeField] public string name;
    [SerializeField] public Transform character;
    [SerializeField] public int Scene;
    [SerializeField] public bool flag;
    // [SerializeField] public ;

    public int GetPlace()
    {
        throw new System.NotImplementedException();
    }

    public string GetText()
    {
        throw new System.NotImplementedException();
    }
}

