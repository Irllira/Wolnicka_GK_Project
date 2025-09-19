using UnityEngine;

/*
 * <summary>
 * This class is responsible for controlling how Tree interaction works
 * </summary>
 * */
public class TreeInteraction : MonoBehaviour, InteractionInterface
{
    [SerializeField] private string interactText;

    public bool CanInteract(ItemsManager inventory)
    {
        if (inventory.CheckInventory("Wood")||!inventory.CheckChosenItem("Axe"))
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
        Debug.Log("Let's cut a tree");

    }
}
