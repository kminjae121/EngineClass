using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controll;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerInputActions
{
    private Controll _controll;
    public event Action JumpKeyEvent;
    public event Action<Vector2> MovementEvent;
    public Vector2 Movement { get; set; }


    private void OnEnable()
    {
        if (_controll == null)
        {
            _controll = new Controll();
            _controll.PlayerInput.SetCallbacks(this);
        }
        _controll.PlayerInput.Enable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpKeyEvent?.Invoke();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(Movement);
    }
}
