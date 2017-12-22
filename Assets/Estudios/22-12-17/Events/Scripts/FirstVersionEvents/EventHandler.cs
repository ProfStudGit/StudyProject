using UnityEngine;
using UnityEngine.Events;//------------------------------------------//

namespace Estudios.Events
{
    public class EventHandler : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_OnStart;

        [SerializeField]
        private UnityEvent m_OnEnd;

        private MovementHandler m_MoveHandler;

        private void Start()
        {
            //Get the movement handler component.
            m_MoveHandler = GetComponent<MovementHandler>();

            //Invoke the onStart events.
            if (m_OnStart != null)
                m_OnStart.Invoke();
        }

        private void Update()
        {
            //If all objects have finished moving, invoke onEnd.
            if (m_MoveHandler.AllDone())
                m_OnEnd.Invoke();
        }
    }
}