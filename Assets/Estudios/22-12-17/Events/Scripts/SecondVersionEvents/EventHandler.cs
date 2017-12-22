using UnityEngine;
using UnityEngine.Events;//------------------------------------------//

namespace Estudios.Events.Second
{
    public class EventHandler : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_OnStart;

        [SerializeField]
        private UnityEvent m_OnEnd;

        private EventManager m_EventManager;

        private void Start()
        {
            //Get the event manager component.
            m_EventManager = GetComponent<EventManager>();
            //Subscribe to the movement done start.
            m_EventManager.MovementDone.SubscribeToStart(OnMovementFinished);

            //Invoke the onStart events.
            if (m_OnStart != null)
                m_OnStart.Invoke();
        }

        private void OnMovementFinished()
        {
            //Invoke the onEnd events.
            if (m_OnEnd != null)
                m_OnEnd.Invoke();
        }
    }
}