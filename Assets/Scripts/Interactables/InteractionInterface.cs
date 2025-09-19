using UnityEngine;


/*
 * <summary>
 * This is interaction interface it is used on game objects that can be interacted with
 * </summary>
 */
public interface InteractionInterface
{
    bool CanInteract(ItemsManager inventory);
    void Interact();
    string GetText();
    Transform GetTransform();
}
