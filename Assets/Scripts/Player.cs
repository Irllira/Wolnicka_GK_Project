using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    #region Movment
    Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;
    [SerializeField] private float speed = 7f;

    [SerializeField] private float rotationSpeed = 500f;

    private float _gravity = -9.18f;
    [SerializeField] private float gravMultipl = 3.0f;
    private float _velocity;
    #endregion

    #region Camera
    private Camera _mainCamera;

    #endregion

    #region Basic Info
    [SerializeField] private float interactionDistance = 2.0f;
    [SerializeField] protected GameObject Model;
    #endregion

    #region Inventory
    private ItemsManager playerInventory;
    [SerializeField] private ItemsMenuUI itemsMenuUI;
    #endregion

    #region Dialog
    private bool dialogPlaying = false;
    private DialogFlagController dfc;
    [SerializeField] private ScenePlayer playingScene;
    #endregion


    private void Awake()
    {
        playerInventory = new ItemsManager();
        itemsMenuUI.SetInventory(playerInventory);                              //Create Inventory
        dfc = GetComponent<DialogFlagController>();

        _characterController = GetComponent<CharacterController>();             //SetCamera
        _mainCamera = Camera.main;
    }


    private void Update()
    {
        if (dialogPlaying == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))                               //Exit from dialog
            {
                EndDialogWindow();
            }
            
        /*    if (playingScene.GetCurrentType() == "Other")
             {
                OtherDialogOption flag = playingScene.GetFlag();
                dfc.ChangeFlag(flag.name);
            }*/


            if(playingScene.GetCurrentType()=="Item")
            {
                GiveItems it = playingScene.GetItem();
                Item item =it.item.GetComponent<Item>();

                if (it.add_delete)
                {
                    playerInventory.AddItem(item);
                }
                else
                {
                    playerInventory.RemoveItem(item);
                }
                itemsMenuUI.SetInventory(playerInventory);
                dfc.UpdateFlags(playerInventory);
                playingScene.PlayNext(dfc);

            }
            
            if (Input.GetKeyDown(KeyCode.Space) && playingScene.PlayNext(dfc) == false)    //Dialog finished
            {
                EndDialogWindow();
            }

            if(playingScene.IsChoiceActive()==true)
            {
               if( Input.GetKeyDown(KeyCode.UpArrow))
                {
                    playingScene.SetChoice(true);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    playingScene.SetChoice(false);
                }
            }
        }
        else
        {
            ApplyRotation();
            ApplyGravity();
            ApplyMove();                                                            //Movment


            CheckInteraction();

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerInventory.ChangeChosenItem(true);
                itemsMenuUI.SetInventory(playerInventory);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerInventory.ChangeChosenItem(false);
                itemsMenuUI.SetInventory(playerInventory);
            }
            //dfc.UpdateFlags(playerInventory);
        }
    }

    #region Interactions Methods
    private void CheckInteraction()
    {
        Item item = null;
        Character character = null;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider[] colArray = Physics.OverlapSphere(transform.position, interactionDistance);
            foreach (Collider collider in colArray)
            {
                if (collider.TryGetComponent(out InteractionInterface interactable) && interactable.CanInteract(playerInventory) == true)
                {
                    interactable.Interact();
                    item = collider.GetComponent<Item>();
                    character = collider.GetComponent<Character>();
                    if (item != null)
                    {
                        playerInventory.AddItem(item);
                        itemsMenuUI.SetInventory(playerInventory);
                    }
                    if (character != null)
                    {
                        StartDialogWindow(character);
                    }
                }
            }
        }

    }

    public InteractionInterface GetInteraction()
    {
        if (dialogPlaying)
            return null;
        List<InteractionInterface> interactableList = new List<InteractionInterface>();
        Collider[] colArray = Physics.OverlapSphere(transform.position, interactionDistance);
        foreach (Collider collider in colArray)
        {
            if (collider.TryGetComponent(out InteractionInterface interactable) && interactable.CanInteract(playerInventory))
                interactableList.Add(interactable);
        }
        if (interactableList.Count == 0)
        {
            return null;
        }


        InteractionInterface closestInteraction = interactableList[0];
        Vector3 buffPosition = transform.position;

        foreach (InteractionInterface interaction in interactableList)
        {
            if (Vector3.Distance(buffPosition, interaction.GetTransform().position) < Vector3.Distance(buffPosition, closestInteraction.GetTransform().position))
                closestInteraction = interaction;
        }

        return closestInteraction;

    }

    #endregion

    private void StartDialogWindow(Character character)
    {
        if(character.GetName()!= "Little Red")
        {
            dfc.RedWolfFlag(character);
        }
        dfc.RaiseFlags();
        dialogPlaying = true;
        HideCharacter();
        Scene scene = character.GetScene();
        playingScene.SetScene(scene,playerInventory,character,dfc);
        itemsMenuUI.HideInventory();

       // interactionDistance = 0;

    }
    private void EndDialogWindow()
    {
        dialogPlaying = false;
        ShowCharacter();
        //  interactionDistance = 2;
        playingScene.HideScene();
        itemsMenuUI.ShowInventory();
    }

    private void ShowCharacter()
    {
        Model.SetActive(true);
    }
    private void HideCharacter()
    {
        Model.SetActive(false);
    }
    public bool GetDialogPlaying()
    {
        return dialogPlaying;
    }

    public ScenePlayer GetScenePlayer()
    {
        return playingScene;
    }

    #region Movment Methods
    private void ApplyMove()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }
    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0)
            return;

        Vector3 v = new Vector3(_input.x, 0.0f, _input.y);
        _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * v;

        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravMultipl * Time.deltaTime;
            _direction.y = _velocity;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    #endregion
}
