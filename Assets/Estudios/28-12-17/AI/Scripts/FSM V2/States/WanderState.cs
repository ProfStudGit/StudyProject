using UnityEngine;
using UnityEngine.AI;

namespace Estudios.AI.V2
{
    [System.Serializable]
    public class WanderState : State
    {
        [SerializeField]
        private float m_MaxDistance;

        [SerializeField]
        private float m_Speed;

        private NavMeshAgent m_Agent;
        private Vector3 m_WanderPoint;

        public override void OnStateEnter(Transform ai)
        {
            if (m_Agent == null)
                m_Agent = ai.GetComponent<NavMeshAgent>();

            m_Agent.speed = m_Speed;
        }

        public override void OnStateUpdate()
        {
            if (m_Agent.remainingDistance < 1f)
                m_WanderPoint = GetNextWanderPos(m_Agent.transform.position);

            m_Agent.SetDestination(m_WanderPoint);
        }

        public Vector3 GetNextWanderPos(Vector3 cPos)
        {
            Vector3 nextPos = cPos;

            //Find a position around the character. (In a box)
            nextPos.x = Random.Range(cPos.x - m_MaxDistance, cPos.x + m_MaxDistance);
            nextPos.z = Random.Range(cPos.z - m_MaxDistance, cPos.z + m_MaxDistance);

            return nextPos;
        }
    }
}