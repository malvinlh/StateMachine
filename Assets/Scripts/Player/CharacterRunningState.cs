using UnityEngine;

public class CharacterRunningState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        Debug.Log("Entering Running State");
        character.animator.SetBool("isRunning", true); // Atur animasi Running
    }

    public override void UpdateState(CharacterStateManager character)
    {
        // Ambil input pemain
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 0.1f)
        {
            // Rotasi ke arah input
            character.Rotate(direction.normalized);

            // Gerakkan karakter
            character.Move(direction.normalized);
        }
        else
        {
            // Beralih kembali ke Idle State
            character.SwitchState(character.idleState);
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        Debug.Log("Exiting Running State");
    }
}
