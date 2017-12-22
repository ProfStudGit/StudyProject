using UnityEngine;

namespace Estudios.Spring
{
    public class SmoothSpring : MonoBehaviour
    {
        public enum LerpType
        {
            Sinerp, Coserp, SmoothStep, Normal
        }

        [SerializeField]
        private LerpType m_Type;

        [SerializeField]
        private int m_Time;

        [SerializeField]
        private Vector3 m_EndPos;

        private float m_SinceStart;

        private Vector3 m_StartPos;
        private Vector3 m_CurrentDestination;

        private void Start()
        {
            m_StartPos = transform.position;

            m_CurrentDestination = m_StartPos;
        }

        private void Update()
        {
            m_SinceStart += Time.deltaTime;
            if (m_SinceStart >= m_Time)
            {
                m_SinceStart = 0f;

                m_CurrentDestination = (m_CurrentDestination == m_StartPos) ? m_EndPos : m_StartPos;
            }

            float progress = ReturnProgress();
            transform.position = Vector3.Lerp(transform.position, m_CurrentDestination, progress);
        }

        private float ReturnProgress()
        {
            float progress = m_SinceStart / m_Time;

            if (m_Type == LerpType.Coserp)
                progress = 1f - Mathf.Cos(progress * Mathf.PI * 0.5f);
            else if (m_Type == LerpType.Sinerp)
                progress = Mathf.Sin(progress * Mathf.PI * 0.5f);
            else if(m_Type == LerpType.SmoothStep)
                progress = progress * progress * (3f - 2f * progress);

            return progress;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
                return;

            Gizmos.color = Color.green;

            Gizmos.DrawLine(m_StartPos, m_EndPos);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_EndPos, 0.5f);
            Gizmos.DrawWireSphere(m_StartPos, 0.5f);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(m_CurrentDestination, 1f);
        }
    }
}