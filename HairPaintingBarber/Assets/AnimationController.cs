using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    Bool_ScriptableObjectEvent m_JobsDone;
    [SerializeField]
    Animator m_Controller;
    [SerializeField]
    GameObject m_Mirror;

    void OnEnable()
    {
        m_JobsDone.AddListener(value =>m_Controller.SetBool("JobsDone",value));
        m_JobsDone.AddListener(value =>m_Mirror.SetActive(value));
    }
}
