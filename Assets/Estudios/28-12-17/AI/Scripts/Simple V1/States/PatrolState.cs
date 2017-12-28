using UnityEngine;

namespace Estudios.AI
{
    [System.Serializable]
    public class PatrolState : AIState
    {
        [SerializeField]
        private Transform[] m_PatrolPoints;

        private int m_CurrentPoint = -1;

        public Vector3 GetNextPoint()
        {
            m_CurrentPoint++;

            if (m_CurrentPoint > m_PatrolPoints.Length - 1)
                m_CurrentPoint = 0;

            return m_PatrolPoints[m_CurrentPoint].position;
        }
    }
}