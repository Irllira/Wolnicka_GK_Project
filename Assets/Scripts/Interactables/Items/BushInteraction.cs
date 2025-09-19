using UnityEngine;


/*
 * <summary>
 * This class is responsible for controlling how Bush interaction works
 * </summary>
 * */
public class BushInteraction : MonoBehaviour, InteractionInterface
{
    [SerializeField] private string interactText;

    public bool CanInteract(ItemsManager inventory)
    {
        if (inventory.CheckInventory("Stick"))
            return false;
        return true;
    }

    public string GetText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        Debug.Log("LookForSticks");

    }
}
