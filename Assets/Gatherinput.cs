using UnityEngine;
using UnityEngine.InputSystem; //Using namespace

public class Gatherinput : MonoBehaviour
{
    //Controls class -> generate from Input action
    private Contol myControl;
    public float valueX;
    public bool jumpInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Awake()
    {
        myControl = new Contol();
    }
    private void OnEnable()
    {
        myControl.Player.Move.performed += StartMove;
        myControl.Player.Move.canceled += StopMove;
        myControl.Player.Jump.performed += JumpStart;   //add new
        myControl.Player.Jump.canceled += JumpStop;     //add new
        myControl.Player.Enable();
    }
    public void OnDisable()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;
        myControl.Player.Jump.performed -= JumpStart;   //add new
        myControl.Player.Jump.canceled -= JumpStop;     //add new
        myControl.Player.Disable();
        valueX= 0;
    }
    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
    }
    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }
    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }
    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }
}