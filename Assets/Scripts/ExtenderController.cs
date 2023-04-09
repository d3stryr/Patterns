using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ExtenderController : ExtenderBase
{
    
    [SerializeField] private Fin m_fin;
    [Range(3,10)]
    [SerializeField] private int m_maxFins = 3;

    // Start is called before the first frame update
    protected override void Start()
    {
        transform.DOScale(Vector3.one, m_duration);
        base.Start();
    }

    protected override IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(m_delay);
        transform.DOMoveY(m_extenderLength, m_duration);
        SpawnFins();
    }

    protected override void Update()
    {
        m_lineRenderer.SetPosition(1,transform.position);
        base.Update();
    }

    private void SpawnFins()
    {
        float angle = 360.0f / m_maxFins;
        for (int index = 0; index < m_maxFins; index++)
        {
            Vector3 rotation = Vector3.forward * angle * ( index + 1);
            Quaternion newRotation = Quaternion.Euler(rotation);
            Fin fin = Instantiate(m_fin, Vector3.zero,newRotation, transform);
        }
    }
}
