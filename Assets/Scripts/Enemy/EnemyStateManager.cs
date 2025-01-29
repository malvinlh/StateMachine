using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState currentState;

    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyRunningState runningState = new EnemyRunningState();

    [Header("References")]
    public Animator animator; // Animator untuk animasi
    public NavMeshAgent agent; // NavMeshAgent untuk pergerakan
    public Transform player; // Referensi ke pemain

    [Header("Settings")]
    public float detectionRange = 10f; // Radius deteksi pemain

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
