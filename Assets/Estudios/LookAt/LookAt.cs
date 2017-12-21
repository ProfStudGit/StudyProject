using UnityEngine;

namespace LookAt
{
    public class LookAt : MonoBehaviour
    {
        public enum LookType
        {
            LookAtNormal, Custom
        }

        [SerializeField]
        private Transform m_Target;

        [SerializeField]
        private LookType m_Type;

        [SerializeField]
        private float m_Speed;

        private void Update()
        {
            if (m_Type == LookType.LookAtNormal)
                transform.LookAt(m_Target.position);
            else if(m_Type == LookType.Custom)
            {
                Quaternion look = Quaternion.LookRotation(m_Target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * m_Speed);
            }
        }
    }
}