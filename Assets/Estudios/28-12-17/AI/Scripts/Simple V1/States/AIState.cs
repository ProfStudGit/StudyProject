using UnityEngine;

namespace Estudios.AI
{
    [System.Serializable]
    public class AIState
    {
        public float Speed { get { return m_Speed; } }

        [SerializeField]
        private float m_Speed;
    }
}