using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationAreaController : MonoBehaviour
{
    [SerializeField]
    Bool_ScriptableObjectEvent m_MovementSettings;

    [SerializeField]
    TeleportationArea m_area;

    void OnEnable()
    {
        m_MovementSettings.AddListener(value=>m_area.enabled=value);
    }
}
