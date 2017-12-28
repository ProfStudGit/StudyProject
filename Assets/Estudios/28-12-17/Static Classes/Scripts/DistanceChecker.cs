using UnityEngine;

namespace Estudios.StaticClasses
{
    public class DistanceChecker : MonoBehaviour
    {
        private void Start()
        {
            //Get the player object from the game manager.
            Transform playerObject = GameManager.Instance.Player.transform;

            //Check the distance towards the player and debug it.
            float distanceToPlayer = Vector3.Distance(playerObject.position, transform.position);
            Debug.Log("Distance to player: " + distanceToPlayer);

            //Get the main camera object from the game manager.
            Transform mainCameraObject = GameManager.Instance.MainCamera.transform;

            //Check the distance towards the camera and debug it.
            float distanceToCamera = Vector3.Distance(mainCameraObject.position, transform.position);
            Debug.Log("Distance to camera: " + distanceToCamera);
        }
    }
}