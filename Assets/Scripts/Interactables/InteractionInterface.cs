using UnityEngine;

public interface InteractionInterface
{

    bool CanInteract(ItemsManager inventory);
    void Interact();
    string GetText();
    Transform GetTransform();
}
