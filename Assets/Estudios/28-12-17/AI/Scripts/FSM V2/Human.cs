using UnityEngine;

namespace Estudios.AI.V2
{
    public class Human : FSMController
    {
        [SerializeField]
        private WanderState m_Wander;

        protected override void ManageStates()
        {
            SetCurrent(m_Wander);
        }
    }
}