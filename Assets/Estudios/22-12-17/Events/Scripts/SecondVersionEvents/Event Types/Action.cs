using UnityEngine.Events;

namespace Estudios.Events.Second
{
    public class Action
    {
        private UnityEvent m_OnStart;

        public void SubscribeToStart(UnityAction action) { m_OnStart.AddListener(action); }

        public void Start()
        {
            if (m_OnStart != null)
                m_OnStart.Invoke();
        }
    }
}