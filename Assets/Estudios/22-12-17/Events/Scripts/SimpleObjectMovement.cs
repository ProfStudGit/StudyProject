using UnityEngine;

namespace Estudios.Events
{
    public class SimpleObjectMovement : MonoBehaviour
    {
        [SerializeField]
        private Vector3[] m_Positions;

        [SerializeField]
        private float m_Speed;

        private Vector3 m_Destination;

        private void Start() { m_Destination = transform.position; }

        private void Update()
        {
            //Move the object towards its objective.
            transform.position = Vector3.Lerp(transform.position, m_Destination, Time.deltaTime * m_Speed);
        }

        public void MoveToFirstPos() { m_Destination = m_Positions[0]; }

        public void MoveToSecondPos() { m_Destination = m_Positions[1]; }
    }
}