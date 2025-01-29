// Third-Person to Side-Scrolling Transition with Cinemachine

using UnityEngine;
using Unity.Cinemachine;

public class CameraTransition : MonoBehaviour
{
    public CinemachineCamera thirdPersonCamera;
    public CinemachineCamera sideScrollingCamera;

    private bool isSideScrolling = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Toggle camera state
            isSideScrolling = !isSideScrolling;

            if (isSideScrolling)
            {
                // Activate side-scrolling camera
                sideScrollingCamera.Priority = 10;
                thirdPersonCamera.Priority = 0;
            }
            else
            {
                // Return to third-person camera
                sideScrollingCamera.Priority = 0;
                thirdPersonCamera.Priority = 10;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // No action needed on exit since state toggles on enter
    }
}
