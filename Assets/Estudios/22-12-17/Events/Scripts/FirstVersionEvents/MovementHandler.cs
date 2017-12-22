using UnityEngine;

namespace Estudios.Events
{
    public class MovementHandler : MonoBehaviour
    {
        [SerializeField]
        private MovableObject[] m_ToMove;

        private void Update()
        {
            //Go trough all the movable objects.
            for (int i = 0; i < m_ToMove.Length; i++)
            {
                //Get the current one.
                MovableObject current = m_ToMove[i];

                //Update it.
                current.Update(Time.deltaTime);
            }
        }

        public bool AllDone()
        {
            //Go trough all the movable objects.
            for (int i = 0; i < m_ToMove.Length; i++)
            {
                //Get the current one.
                MovableObject current = m_ToMove[i];

                //If one is not done, stop checking.
                if (current.IsDone() == false)
                    return false;
            }

            return true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            //Draw a wire sphere for each end position.
            for (int i = 0; i < m_ToMove.Length; i++)
                Gizmos.DrawWireSphere(m_ToMove[i].EndPosition, 1f);
        }
    }

    [System.Serializable]
    public class MovableObject
    {
        public Vector3 EndPosition { get { return m_EndPosition; } }

        [SerializeField]
        private Transform m_Object;

        [SerializeField]
        private Vector3 m_EndPosition;

        [SerializeField]
        private float m_Time = 2f;

        private float m_SinceStart;

        public void Update(float deltaTime)
        {
            //Add to the time that has passed.
            m_SinceStart += deltaTime;

            //If the time has been completed.
            if (m_SinceStart >= m_Time)
            {
                //Make sure the value doesn't go above it.
                m_SinceStart = m_Time;
            }

            //Calculate the percentage that has been completed (0, 1).
            float progress = m_SinceStart / m_Time;
            //Lerp the object to the destination.
            m_Object.position = Vector3.Lerp(m_Object.position, m_EndPosition, progress);
        }

        public bool IsDone() { return m_Object.position == m_EndPosition; }
    }
}