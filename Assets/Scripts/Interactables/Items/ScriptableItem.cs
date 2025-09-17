using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableItem", menuName = "Scriptable Objects/ScriptableItem")]
public class ScriptableItem : ScriptableObject
{
    public string itemType;
    public string itemName;
    public Sprite image;
    public Transform model;
    public string interactionText;
    bool ifAcquired;
}
