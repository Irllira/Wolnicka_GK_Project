using UnityEngine;

public class CrumbInteraction : MonoBehaviour, InteractionInterface
{
    [SerializeField] private string interactText;

    public bool CanInteract(ItemsManager inventory)
    {
        if(inventory.CheckInventory("Bread Crumb"))
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
        Debug.Log("This is a crumb");
    }
}
