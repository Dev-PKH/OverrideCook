using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 게임 입력 처리(상호작용 등)
public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction; // 상호작용 이벤트 핸들러
    public event EventHandler OnInteractAlternateAction; // 슬라이스 상호작용 이벤트 핸들러

    private PlayerInputActions playerInputActions; // InputSystem

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed; // 상호작용 키 입력 시 실행할 이벤트
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty); // 이벤트 핸들러(상호작용 전용) 실행
    }

    public Vector2 GetMovementVeectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
