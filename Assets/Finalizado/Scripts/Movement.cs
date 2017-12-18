using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed;

    [SerializeField]
    private float m_DampTime;

    private Animator m_Animator;

    private void Awake() { m_Animator = GetComponent<Animator>(); }

    private void Update()
    {
        if (m_Animator == null)
            return;

        float horizontalSpeed = Input.GetAxis("Vertical") * m_MovementSpeed;
        float verticalSpeed = Input.GetAxis("Horizontal") * m_MovementSpeed;

        m_Animator.SetFloat("Vertical", horizontalSpeed, m_DampTime, Time.deltaTime);
        m_Animator.SetFloat("Horizontal", verticalSpeed, m_DampTime, Time.deltaTime);
    }
}