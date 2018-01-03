using UnityEngine;

namespace CosasSerias.Shaders
{
    public class Disolve : MonoBehaviour
    {
        [SerializeField]
        private Material m_DisolveMaterial;

        [SerializeField]
        private float m_DisolveSpeed;

        [SerializeField]
        private float m_DisolveMax;

        [SerializeField]
        private bool m_Loop;

        private float m_CurrentDisolve;

        private void Update()
        {
            //If we still have to disolve.
            if(m_CurrentDisolve < m_DisolveMax)
            {
                //Add to the current disolve.
                m_CurrentDisolve += Time.deltaTime * m_DisolveSpeed;

                m_DisolveMaterial.SetFloat("_DisolveAmount", m_CurrentDisolve);

                return;
            }

            if (m_Loop)
                m_CurrentDisolve = 0f;

            //Reset disolving.
            if (Input.GetKeyDown(KeyCode.E))
                m_CurrentDisolve = 0f;
        }
    }
}