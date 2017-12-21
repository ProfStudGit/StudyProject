using UnityEngine;
using UnityEngine.UI;

namespace Spring
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Text m_Text;

        [SerializeField]
        private Transform[] m_Targets;

        [SerializeField]
        private Vector3 m_Offset;

        [SerializeField]
        private float m_Speed;

        private int m_Current;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                m_Current++;

                if (m_Current > m_Targets.Length - 1)
                    m_Current = 0;
            }

            Vector3 nextPos = m_Targets[m_Current].position + m_Offset;
            transform.position = Vector3.Lerp(transform.position, nextPos, Time.deltaTime * m_Speed);

            transform.LookAt(m_Targets[m_Current]);
            m_Text.text = "Lerp Type: " + m_Targets[m_Current].name;
        }
    }
}