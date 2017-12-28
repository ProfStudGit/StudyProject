using UnityEngine;

namespace Estudios.StaticClasses
{
    public class GameManager : MonoBehaviour
    {
             ///||||/////MAKES THIS WORK WITH THE OBJECT IN THE SCENE OR NOT.
        public static GameManager Instance
        {
            get 
            {
                //Try to find a game manager in the scene.
                GameManager manager = FindObjectOfType<GameManager>();

                //If we haven't found one.
                if(!manager)
                {
                    //Create an object and add one to it.
                    GameObject newObject = new GameObject("Game Manager");
                    manager = newObject.AddComponent<GameManager>();
                }

                return manager;
            }
        }

        public Player Player { get { return m_Player; } }
        public Camera MainCamera { get { return m_MainCamera; } }

        public GameObject[] SpawnPoints { get { return m_SpawnPoints; } }

        private Player m_Player;
        private Camera m_MainCamera;
        private GameObject[] m_SpawnPoints;

        private void Awake()
        {
            //Find the player by searching for the script attached to it.
            m_Player = FindObjectOfType<Player>();

            //Find the camera by searching for its "camera" component. (Only works because there's only one camera in the scene)
            m_MainCamera = FindObjectOfType<Camera>();

            //Find the spawn point by the tag they have assigned.
            m_SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        }
    }
}