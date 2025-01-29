using UnityEngine;

public class EnemyRunningState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Running State");
        enemy.animator.SetBool("isRunning", true); // Set animasi ke Running
        enemy.agent.isStopped = false; // Mulai bergerak
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        // Tetapkan tujuan ke posisi pemain
        enemy.agent.destination = enemy.player.position;

        // Jika pemain keluar dari detection range, kembali ke Idle
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) > enemy.detectionRange)
        {
            enemy.SwitchState(enemy.idleState);
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Exiting Running State");
    }
}
