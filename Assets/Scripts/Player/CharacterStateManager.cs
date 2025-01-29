using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public CharacterBaseState currentState;
    public CharacterBaseState idleState = new CharacterIdleState();
    public CharacterBaseState runningState = new CharacterRunningState();

    public Animator animator; // Tambahkan referensi Animator
    public float moveSpeed = 5f; // Kecepatan bergerak
    private CharacterController characterController; // Untuk mengontrol pergerakan

    void Start()
    {
        currentState = idleState;

        characterController = GetComponent<CharacterController>(); // Ambil komponen CharacterController
        currentState.EnterState(this);
    }

    void Update()
    {
        // Pindahkan input ke currentState
        currentState.UpdateState(this);
    }

    public void Move(Vector3 direction)
    {
        // Gerakkan karakter
        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }
    
    public void Rotate(Vector3 direction)
    {
        if (direction.magnitude > 0.1f) // Hanya rotasi jika ada input
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    public void SwitchState(CharacterBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
