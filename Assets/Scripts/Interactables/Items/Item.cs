using UnityEngine;

public class Item : MonoBehaviour
{
   // [SerializeField] InteractionInterface interactionClass;
    public ScriptableItem scriptableObject;
    private bool ifAcquired = false;


    public Item(ScriptableItem scriptable)
    {
        scriptableObject = scriptable;
    }

    private void Start()
    {
        
    }
    private void ItemAcuired()
    {
        ifAcquired = true;
    }
    private void ItemLost()
    {
        ifAcquired = false;
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
