using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Idle State");
        enemy.animator.SetBool("isRunning", false); // Set animasi ke Idle
        enemy.agent.isStopped = true; // Hentikan gerakan Enemy
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        // Periksa apakah pemain memasuki detection range
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) < enemy.detectionRange)
        {
            enemy.SwitchState(enemy.runningState);
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Exiting Idle State");
    }
}
