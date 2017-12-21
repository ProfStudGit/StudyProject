using UnityEngine;
using System.Timers;

public class CRESIMIENTOX : MonoBehaviour
{
    public enum Axis
    {
        X, Y, Z, ALL
    }

    [SerializeField]
    private Axis m_GrowAxis;

    [SerializeField]
    private float m_TimeToGrow;

    [SerializeField]
    private int m_MaxGrowth;

    [SerializeField]
    private float m_GrowStep;

    [SerializeField]
    private float m_LerpSpeed;

    [SerializeField]
    private bool m_WOW;

    private int m_CurrentGrowth = 0;
    private float m_LastGrowthTime;

    private Vector3 m_CurrentTarget;

    private void Update()
    {
        //Time.time = 0f;
        //m_LastGrowthTime = 0f;

        if(Time.time - m_LastGrowthTime > m_TimeToGrow)
        {
            if (m_CurrentGrowth <= m_MaxGrowth)
            {
                m_CurrentTarget += Vector3.one * m_GrowStep;
                m_CurrentGrowth++;
            }

            m_LastGrowthTime = Time.time;
        }

        m_CurrentTarget = GetTargetWithAxis();

        if (m_WOW)
            transform.localScale = Vector3.Lerp(transform.localScale, m_CurrentTarget, Time.deltaTime * m_LerpSpeed);
        else
            transform.localScale = m_CurrentTarget;
    }

    private Vector3 GetTargetWithAxis()
    {
        Vector3 newTarget = m_CurrentTarget;

        if(m_GrowAxis == Axis.X)
        {
            newTarget.y = transform.localScale.y;
            newTarget.z = transform.localScale.z;
        }
        else if(m_GrowAxis == Axis.Y)
        {
            newTarget.x = transform.localScale.x;
            newTarget.z = transform.localScale.z;
        }
        else if(m_GrowAxis == Axis.Z)
        {
            newTarget.x = transform.localScale.x;
            newTarget.y = transform.localScale.y;
        }

        return newTarget;
    }
}