using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private Vector3 m_Offset;

    [SerializeField]
    private float m_MoveSpeed;

    private void Update()
    {
        //Get the targets position.
        Vector3 pos = m_Target.localPosition;

        //Add the offset.
        Vector3 posWithOffset = pos;
        posWithOffset += m_Offset;

        Vector3 worldPosWithOffset = m_Target.localToWorldMatrix.MultiplyPoint(posWithOffset);

        //Move this object towards that position.
        transform.position = Vector3.Lerp(transform.position, worldPosWithOffset, Time.deltaTime * m_MoveSpeed);

        //Rotate this object to face the target.
        transform.rotation = Quaternion.Slerp(transform.rotation, m_Target.rotation, Time.deltaTime * m_MoveSpeed);
    }
}