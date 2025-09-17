using UnityEngine;

public class GingerbreadInteraction : MonoBehaviour, InteractionInterface
{
    public bool CanInteract(ItemsManager inventory)
    {
        if (inventory.CheckInventory("Gingerbread"))
            return false;
        return true;
    }

    public string GetText()
    {
        return "Pick up";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        Debug.Log("Tasty");

    }

}
