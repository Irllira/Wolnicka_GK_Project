using UnityEngine;


/*
 * <summary>
 * This class defining a new scriptable object called scriptable character
 * </summary>
 */
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
