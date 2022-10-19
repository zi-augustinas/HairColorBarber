using System;
using ScriptableObjectEvent;
using UnityEngine;

namespace HairBarber
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]
        Bool_ScriptableObjectEvent m_JobsDone;
        [SerializeField]
        Animator m_Controller;

        void OnEnable()
        {
            m_JobsDone.AddListener(EnableAnimationTrigger);
        }

        void OnDisable()
        {
            m_JobsDone.RemoveListener(EnableAnimationTrigger);
        }

        void EnableAnimationTrigger(bool evenValue)
        {
            m_Controller.SetBool("JobsDone", evenValue);
        }
    }
}
