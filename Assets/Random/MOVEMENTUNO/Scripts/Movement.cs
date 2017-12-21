using UnityEngine;

namespace MovimientoUNo.Movimiento
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed;

        [SerializeField]
        private float m_Damp;

        private Animator m_Animator;
        private CharacterController m_CController;

        private void Awake() { m_Animator = GetComponent<Animator>(); m_CController = GetComponent<CharacterController>(); }

        private void Update()
        {
            float vertical = Input.GetAxis("Vertical") * m_Speed;
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 hor = horizontal * Vector3.right;
            Vector3 ver = vertical * Vector3.forward;
            Vector3 total = hor + ver;

            if (m_CController.isGrounded == false)
                total.y += Physics.gravity.y;

            m_CController.Move(total);
            ManageAnimation();
        }

        private void ManageAnimation()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            m_Animator.SetFloat("Horizontal", horizontal, m_Damp, Time.deltaTime);
            m_Animator.SetFloat("Vertical", vertical, m_Damp, Time.deltaTime);
        }
    }
}