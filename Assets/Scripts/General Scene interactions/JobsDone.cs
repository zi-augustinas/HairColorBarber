using System;
using ScriptableObjectEvent;
using UnityEngine;

namespace HairBarber
{
    public class JobsDone : MonoBehaviour
    {
        [SerializeField]
        Bool_ScriptableObjectEvent m_JobsDone;
        [SerializeField]
        GameObject m_Mirror;

        [SerializeField]
        GameObject m_MirrorLocal;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == m_Mirror)
            {
                m_JobsDone.RaiseEvent(true);
                m_Mirror.SetActive(false);
                m_MirrorLocal.SetActive(true);
            }
        }
    }
}
