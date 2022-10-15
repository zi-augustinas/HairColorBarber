using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobsDone : MonoBehaviour
{
    [SerializeField]
    Bool_ScriptableObjectEvent m_JobsDone;
    [SerializeField]
    GameObject m_Mirror;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_Mirror)
        {
            m_JobsDone.RaiseEvent(true);
            m_Mirror.SetActive(false);
        }
    }
}