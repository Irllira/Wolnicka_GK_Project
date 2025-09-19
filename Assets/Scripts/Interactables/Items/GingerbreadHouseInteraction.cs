using UnityEngine;

/*
 * <summary>
 * This class is responsible for controlling how Gingerbread house interaction works
 * </summary>
 * */
public class GingerbreadHouseInteraction : MonoBehaviour, InteractionInterface
{
    [SerializeField] private string interactText;
    [SerializeField] private GameObject player;

    private DialogFlagController dfc;

    private void Awake()
    {
        dfc = player.GetComponent<DialogFlagController>();

    }

    public bool CanInteract(ItemsManager inventory)
    {
        if (!inventory.CheckChosenItem("BottleCap")|| dfc.CheckFlag("WitchHouseEaten"))
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
        dfc.ChangeFlag("WitchHouseEaten");

    }
}
