using UnityEngine;

namespace Estudios.StaticClasses
{
    public class Player : MonoBehaviour
    {
        //Don't do things in awake because the gameManager finds the references then.
        private void Start()
        {
            //Get the spawn points from the game manager.
            GameObject[] spawnPoints = GameManager.Instance.SpawnPoints;

            //Select a random one.
            int randomPoint = Random.Range(0, spawnPoints.Length);

            //Move to the point that we've selected randomly.
            transform.position = spawnPoints[randomPoint].transform.position;
        }
    }
}