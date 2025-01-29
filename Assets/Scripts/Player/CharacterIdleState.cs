using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        Debug.Log("Entering Idle State");
        character.animator.SetBool("isRunning", false); // Atur animasi Idle
    }

    public override void UpdateState(CharacterStateManager character)
    {
        // Cek input pemain untuk berjalan/berlari
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 0.1f)
        {
            // Beralih ke Running State
            character.SwitchState(character.runningState);
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        Debug.Log("Exiting Idle State");
    }
}
