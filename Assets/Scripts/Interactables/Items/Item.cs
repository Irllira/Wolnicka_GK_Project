using UnityEngine;


/*
 * <summary>
 * This class is placed in a game object to signify it is an item
 * </summary>
 */
public class Item : MonoBehaviour
{
   // [SerializeField] InteractionInterface interactionClass;
    public ScriptableItem scriptableObject;
  //  private bool ifAcquired = false;


    public Item(ScriptableItem scriptable)
    {
        scriptableObject = scriptable;
    }

    public string GetItemName()
    {
        return scriptableObject.itemName;
    }

    public Transform GetObject()
    {
        return scriptableObject.model;
    }

    public Sprite GetSprite()
    {
        return scriptableObject.image;
    }

    public ScriptableItem GetScriptable()
    {
        return scriptableObject;
    }
}
