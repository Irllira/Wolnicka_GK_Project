using UnityEngine;

public class GameInput : MonoBehaviour {

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector3 GetMovementVector() {  
    
    Vector2 v =playerInputActions.Player.Move.ReadValue<Vector2>();
      Vector3 inputvector = new Vector3(v.x, 0, v.y);

      

    inputvector = inputvector.normalized;

    return inputvector;
}
}
