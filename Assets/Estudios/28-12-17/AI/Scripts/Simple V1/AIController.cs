using UnityEngine;
using UnityEngine.AI;

namespace Estudios.AI
{
    public class AIController : MonoBehaviour
    {
        public enum State { Wander, Patrol }

        [Header("States")]

        [SerializeField]
        private WanderState m_Wander;

        [SerializeField]
        private PatrolState m_Patrol;

        [Header("Debug")]

        [SerializeField]
        private State m_State;

        private NavMeshAgent m_Agent;

        private Vector3 m_NextMove;

        private void Awake() { m_Agent = GetComponent<NavMeshAgent>(); }

        private void Update()
        {
            if (m_State == State.Wander)
                WanderAroundState();
            else
                PatrolState();
        }

        private void PatrolState()
        {
            //If we're close to the current point, change point.
            if(m_Agent.remainingDistance < 1f)
                m_NextMove = m_Patrol.GetNextPoint();

            //Move to the current destination.
            m_Agent.SetDestination(m_NextMove);

            //Change the current speed.
            m_Agent.speed = m_Patrol.Speed;
        }

        private void WanderAroundState()
        {
            //If we're close to the current wander position.
            if(m_Agent.remainingDistance <= 1f)
            {
                //Find the next wander position.
                m_NextMove = m_Wander.GetNextWanderPos(transform.position);

                //Change the speed.
                m_Agent.speed = m_Wander.Speed;
            }

            //Move there.
            m_Agent.SetDestination(m_NextMove);
        }
    }
}