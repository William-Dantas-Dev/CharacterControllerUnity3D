using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CameraController cameraController;


    [Header("Mobile")]
    [SerializeField] private bool useMobile;
    [SerializeField] private GameObject mobileCanvas;

    private InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        RefreshOnScreenControls();
    }

    private void OnValidate()
    {
        RefreshOnScreenControls();
    }

    private void RefreshOnScreenControls()
    {
        mobileCanvas.SetActive(useMobile);
        Cursor.visible = useMobile;
    }
    void Update()
    {
        //var h = Input.GetAxisRaw("Horizontal");
        //var v = Input.GetAxisRaw("Vertical");
        //var wantsToJump = Input.GetKeyDown(KeyCode.Space);

        var moveInput = inputActions.Game.Move.ReadValue<Vector2>();
        var wantsToJump = inputActions.Game.Jump.WasPressedThisFrame();

        characterMovement.SetInput(new CharacterMovementInput()
        {
            MoveInput = moveInput,
            LookRotation = cameraController.LookRotation,
            WantsToJumps = wantsToJump,
        });

        //var lookX = -Input.GetAxisRaw("Mouse Y");
        //var lookY = Input.GetAxisRaw("Mouse X");

        var look = inputActions.Game.Look.ReadValue<Vector2>();

        cameraController.IncrementLookRotation(new Vector2(look.y, look.x));
    }
}
