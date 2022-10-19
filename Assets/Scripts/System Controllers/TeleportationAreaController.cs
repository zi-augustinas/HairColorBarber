using System;
using ScriptableObjectEvent;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace HairBarber
{
    public class TeleportationAreaController : MonoBehaviour
    {
        [SerializeField]
        Bool_ScriptableObjectEvent m_MovementSettings;

        [SerializeField]
        TeleportationArea m_area;

        void OnEnable()
        {
            m_MovementSettings.AddListener(DisableTeleportArea);
        }

        void OnDisable()
        {
            m_MovementSettings.RemoveListener(DisableTeleportArea);
        }

        void DisableTeleportArea(bool eventValue)
        {
            m_area.enabled = eventValue;
        }
    }
}
