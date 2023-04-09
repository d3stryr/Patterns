using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Fin : ExtenderBase
{
    [SerializeField] private GameObject m_afterPath;

    private bool m_canLeaveTrail = false;

    protected override void Start()
    {
        transform.DOScale(Vector3.one, m_duration);
        base.Start();
    }

    protected override IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(m_delay);
        Vector3 newPosition = transform.up * m_extenderLength;
        transform.DOLocalMove(newPosition, m_duration);
        Invoke(nameof(StartRotating), m_duration);
    }

    private void StartRotating()
    {
        EventManager.SendOnStartRotating();
        m_canLeaveTrail = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_lineRenderer.SetPosition(0,transform.parent.position);
        m_lineRenderer.SetPosition(1,transform.position);
        if (m_canLeaveTrail)
        {
            GameObject trail = Instantiate(m_afterPath);
            trail.transform.position = transform.position;
        }
    }
}
