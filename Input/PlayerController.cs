using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 move;
    private Vector2 direction;
    private int bindPressed;
    [SerializeField] private Rigidbody playerBody;
    private PlayerManager playerManager;
    private PlayerAttackController attackController;
    private InputActionStack inputActionStack = new InputActionStack();
    private Vector3 mousePos;
    public Gun gun;
    public Vector3 viewVel;

    void Start()
    {
        direction = new Vector2(0, 1);
        playerManager = GetComponent<PlayerManager>();
        attackController = GetComponent<PlayerAttackController>();
        
    }

    public void OnMove(InputAction.CallbackContext context) //Event for collecting Vector2 data tied to movement controls.
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnBasicAttack(InputAction.CallbackContext context) //Event for firing gun tied to the Unity input system. Fires when held.
    {
        if(context.phase == InputActionPhase.Performed)
        {
            inputActionStack.AddToInputStack(1);

        }

        if(context.phase == InputActionPhase.Canceled)
        {
            inputActionStack.RemoveFromInputStack(1);
        }

    }

    public void OnAlternateAttack(InputAction.CallbackContext context) //Event for firing gun tied to the Unity input system. Fires when held.
    {
        if(context.phase == InputActionPhase.Performed)
        {
            inputActionStack.AddToInputStack(2);    
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            inputActionStack.RemoveFromInputStack(2);
        }

    }

    void FixedUpdate()
    {
        MovePlayer();
        LookMouse();
        bindPressed = inputActionStack.GetFromTop();
        if(bindPressed != 0) attackController.PerformAttack(bindPressed);

    }

    public void MovePlayer() //Takes stored movement controls data and applies it to ingame movement.
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        playerBody.linearVelocity = movement * speed * Time.fixedDeltaTime;

        viewVel = playerBody.linearVelocity;
    }

    public void DirectPlayer() //Takes stored direction vector and converts it to a rotation, which is applied to the player.
    {

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0f)
            {
                transform.rotation = Quaternion.Euler(0, 90 ,0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90 ,0);
            }
            
        }
        else
        {
            if(direction.y > 0f)
            {
                transform.rotation = Quaternion.Euler(0, 0 ,0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180 ,0);
            }
        }    

    }

    private void LookMouse()
    {
        mousePos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        if(Physics.Raycast(mouseRay, out RaycastHit hitData))
        {
            transform.forward = new Vector3(hitData.point.x, 0, hitData.point.z) - new Vector3(transform.position.x, 0,transform.position.z);
        }
        
    }

    

}
