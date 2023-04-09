using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExtenderBase : MonoBehaviour
{
    [SerializeField] protected float m_extenderLength;
    [SerializeField] protected float m_duration = 1.5f;
    [SerializeField] protected float m_delay = 1.5f;
    [SerializeField] protected LineRenderer m_lineRenderer;
    [SerializeField] private float m_rotationSpeed;
    
    protected bool m_canRotate = false;

    private void Awake()
    {
        EventManager.OnStartRotating += HandleOnStartRotating;
    }

    protected virtual void Start()
    {
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (m_canRotate)
        {
            Rotate();
        }
    }

    protected virtual void Rotate()
    {
        transform.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);
    }
    
    private void HandleOnStartRotating()
    {
        m_canRotate = true;
    }

    private void OnDestroy()
    {
        EventManager.OnStartRotating -= HandleOnStartRotating;
    }

    protected abstract IEnumerator DelayStart();
}
