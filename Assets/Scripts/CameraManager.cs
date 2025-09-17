using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager: MonoBehaviour
{
    #region Variables

    [SerializeField] private Transform player;
    [SerializeField] private MouseSensitivity sensitivity;
    [SerializeField] private CameraAngle angle;
    
    private Transform target;
    private ScriptableCharacter character;

    private CameraRotation _cameraRotation;
    private Vector2 _input;
    private float _playerDistance;
    private bool cameraLocked = false;
    private Player playerScript;
    
    #endregion
    private void Awake()
    {
        target = player;
        playerScript= player.GetComponent<Player>();
        _playerDistance = Vector3.Distance(transform.position, player.position);
        cameraLocked = false;
    }

    private void Update()
    {
        if(playerScript.GetDialogPlaying() && !cameraLocked)
        {
            LockCamera();
        }
        if(!playerScript.GetDialogPlaying() && cameraLocked)
        {
            UnlockCamera();
        }
        if (!cameraLocked)
        {
            _cameraRotation.yAxis += _input.x * sensitivity.horizontal * Time.deltaTime;
            _cameraRotation.xAxis += _input.y * sensitivity.vertical * Time.deltaTime;
            _cameraRotation.xAxis = Mathf.Clamp(_cameraRotation.xAxis, angle.min, angle.max);
        }
       
    }

    public void Look(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }
    private void LateUpdate()
    { 
        //  transform.position.Set(138, 54, 221);
        if (cameraLocked)
        {
            transform.eulerAngles = character.cameraRotation;
            transform.position = character.characterPosition;
            transform.position = transform.position + character.cameraPositionMove;

        }else
        {
            transform.eulerAngles = new Vector3(-_cameraRotation.xAxis, _cameraRotation.yAxis, 0.0f);
            transform.position = target.position - transform.forward * _playerDistance;
        }
    }

    public void LockCamera()
    {
        cameraLocked = true;

        character=playerScript.GetScenePlayer().GetCharacter();
        
      //  transform.position=transform.position+new Vector3(0f, 0f, 2f);


    }
    public void UnlockCamera()
    {
        cameraLocked = false;
        target = player;
    }
}

[Serializable]
public struct MouseSensitivity
{
    public float vertical;
    public float horizontal;

}

public struct CameraRotation
{
    public float xAxis;
    public float yAxis;
}

[Serializable]
public struct CameraAngle
{
    public float min;
    public float max;
}
