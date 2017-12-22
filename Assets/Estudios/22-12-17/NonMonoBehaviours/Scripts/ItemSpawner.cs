using UnityEngine;

namespace Estudios.NonMonoBehaviours
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField]
        private Item[] m_Items;

        [SerializeField]
        private float m_SpawnRadius;

        [SerializeField]
        private bool m_SpawnAtStart;

        private void Start()
        {
            //Spawn the objects at start if needed.
            if (m_SpawnAtStart)
                SpawnItems();
        }

        private void Update()
        {
            //If we press 'F'.
            if(Input.GetKeyDown(KeyCode.F))
            {
                //Go trough all this object's children and destroy them.
                for (int i = 0; i < transform.childCount; i++)
                    Destroy(transform.GetChild(i).gameObject);

                //Spawn new items.
                SpawnItems();
            }
        }

        private void SpawnItems()
        {
            //Go trough all the items.
            for (int i = 0; i < m_Items.Length; i++)
            {
                //Get the current item.
                Item current = m_Items[i];

                //Find a position for the object around this object but at the same height.
                Vector3 randomPosition = Random.insideUnitCircle * m_SpawnRadius;
                randomPosition.y = transform.position.y;

                //Spawn it.
                current.Spawn(randomPosition, transform);

                //Debug its name.
                Debug.Log(current.Name);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, m_SpawnRadius);
        }
    }

    [System.Serializable]
    public class Item
    {
        public string Name { get { return m_Name; } }

        [SerializeField]
        private string m_Name;

        [SerializeField]
        private GameObject m_Prefab;

        [SerializeField]
        private Vector3 m_SpawnRotation;

        public void Spawn(Vector3 position, Transform parent)
        {
            //Spawn the object.
            GameObject newItem = GameObject.Instantiate(m_Prefab, position, Quaternion.Euler(m_SpawnRotation));

            //Parent it.
            newItem.transform.SetParent(parent);
        }
    }
}