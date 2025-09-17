using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableCharacter", menuName = "Scriptable Objects/ScriptableCharacter")]
public class ScriptableCharacter : ScriptableObject
{
    public string characterName;
    public Transform model;
    public string hello;

    public Vector3 characterPosition;

    public Vector3 cameraPositionMove;
    public Vector3 cameraRotation;
    
}
