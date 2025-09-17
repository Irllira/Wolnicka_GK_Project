using System.Collections.Generic;
using UnityEngine;

public class DisappearController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private List<DisappearCharacter> chara;
    private DialogFlagController dfc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        dfc = player.GetComponent<DialogFlagController>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DisappearCharacter ch in chara)
        {
            if (dfc.CheckFlag("MomGone"))
            {

                if (ch.character.name == "Mom")
                {
                    ch.character.SetActive(false);

                }
                if (ch.character.name == "Mom_With_Red")
                {
                    ch.character.SetActive(true);

                }
            }
            if (dfc.CheckFlag("RedWolf") && ch.character.name == "Wolf")
            {
                ch.character.SetActive(true);
            }


            if (dfc.CheckFlag("MomSavedTheDay") && (ch.character.name == "Mom_With_Red" || ch.character.name == "LittleRed"))
            {
                ch.character.SetActive(false);
               
            }

            if (dfc.CheckFlag("RedGonnaGo") && (ch.character.name == "LittleRed_At_Grandma's" || ch.character.name == "Grandma"))
            {
                ch.character.SetActive(true);
            }

            if (dfc.CheckFlag("MomSavedTheDay") && (ch.character.name == "LittleRed_At_Grandma's" || ch.character.name == "Grandma" || ch.character.name == "Mom_At_Grandmas"))
            {
                ch.character.SetActive(true);
            }

            if(dfc.CheckFlag("RedScared") && ch.character.name == "LittleRed")
            {
                ch.character.SetActive(false);
            }

            if (dfc.CheckFlag("RedScared") && (ch.character.name == "LittleRed_At_Grandma's" || ch.character.name == "Grandma"))
            {
                ch.character.SetActive(true);
            }

            if ((dfc.CheckFlag("WolfRegular")|| dfc.CheckFlag("WolfScared")) && (ch.character.name == "LittleRed_At_Grandma's" || ch.character.name == "Grandma"))
            {
                ch.character.SetActive(true);
            }

            if (dfc.CheckFlag("WolfEats") && (ch.character.name == "LittleRed_At_Grandma's" || ch.character.name == "Grandma"))
            {
                ch.character.SetActive(false);
                
            }

            if (dfc.CheckFlag("WolfEats") && (ch.character.name == "Wolf_At_Grandma" ))
            {
                ch.character.SetActive(true);

            }

            if (dfc.CheckFlag("WolfVomits") && (ch.character.name == "LittleRed_At_Grandma's"))
            {
                ch.character.SetActive(true);
            }

            if (dfc.CheckFlag("WolfVomits") && (ch.character.name == "Wolf_At_Grandma" || ch.character.name == "Grandma"))
            {
                ch.character.SetActive(false);
            }

            if (dfc.CheckFlag("WolfScared") && (ch.character.name == "Wolf"))
            {
                ch.character.SetActive(false);
            }

            if (dfc.CheckFlag("WitchHouseEaten") && (ch.character.name == "BirdsGingerbreadHouse"|| ch.character.name == "HanselAndGrethel"))
            {
                ch.character.SetActive(true);
            }
         
            if((dfc.CheckFlag("KidsSaved")||dfc.CheckFlag("KidsOut")) && ch.character.name== "HanselAndGrethel")
            {
                ch.character.SetActive(true);
            }

            if(dfc.CheckFlag("BuiltSticks") && ch.character.name =="StickHouse" )
            {
                ch.character.SetActive(true);
            }

            if (dfc.CheckFlag("BuiltWood") && ch.character.name == "WoodHouse")
            {
                ch.character.SetActive(true);
            }

            if (dfc.CheckFlag("BuiltBricks") && ch.character.name == "BrickHouse")
            {
                ch.character.SetActive(true);
            }

        }
    }

    public void disappearWolfRed()
    {
        foreach (DisappearCharacter character in chara)
        {
            if(character.character.name== "Wolf" || character.character.name == "LittleRed"|| character.character.name == "Mom_With_Red")
            {
                character.character.SetActive(false);
            }
        }
    }

}


[System.Serializable]
public class DisappearCharacter
{
    [SerializeField] public GameObject character;
}