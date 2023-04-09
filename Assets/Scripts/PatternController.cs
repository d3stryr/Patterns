using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PatternController : ExtenderBase
{
    [SerializeField] private ExtenderController m_extender;

    protected override IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(m_delay);
        m_extender.gameObject.SetActive(true);
    }
}
