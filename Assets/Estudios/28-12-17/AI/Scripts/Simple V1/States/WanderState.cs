using UnityEngine;

namespace Estudios.AI
{
    [System.Serializable]
    public class WanderState : AIState
    {
        [SerializeField]
        private float m_MaxDistance;

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