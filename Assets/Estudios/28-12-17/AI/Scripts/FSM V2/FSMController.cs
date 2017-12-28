using UnityEngine;

namespace Estudios.AI.V2
{
    public class FSMController : MonoBehaviour
    {
        private State m_CurrentState;

        private void Update()
        {
            ManageStates();

            if (m_CurrentState != null)
                m_CurrentState.OnStateUpdate();
        }

        protected void SetCurrent(State newState)
        {
            if (m_CurrentState != null)
                m_CurrentState.OnStateExit();

            m_CurrentState = newState;

            if (m_CurrentState != null)
                m_CurrentState.OnStateEnter(transform);
        }

        protected virtual void ManageStates() { }
    }

    [System.Serializable]
    public class State
    {
        public virtual void OnStateEnter(Transform ai) { }

        public virtual void OnStateUpdate() { }

        public virtual void OnStateExit() { }
    }
}