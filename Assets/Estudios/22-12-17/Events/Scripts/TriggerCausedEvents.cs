using UnityEngine;
using UnityEngine.Events;

namespace Estudios.Events
{
    public class TriggerCausedEvents : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_OnEnter;

        private void OnTriggerEnter(Collider other)
        {
            //Needs rigidbody + collider to be detected.
            Debug.Log(other.name);

            //Invoke onEnter.
            if (m_OnEnter != null)
                m_OnEnter.Invoke();
        }
    }
}