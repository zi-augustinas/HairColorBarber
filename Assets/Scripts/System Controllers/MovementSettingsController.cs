using System;
using ScriptableObjectEvent;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace HairBarber
{
    public class MovementSettingsController : MonoBehaviour
    {
        [SerializeField]
        Bool_ScriptableObjectEvent m_TurnSettings;
        [SerializeField]
        Bool_ScriptableObjectEvent m_MovementSettings;

        SnapTurnProviderBase m_SnapTurnProviderBase;
        ContinuousTurnProviderBase m_ContinuousTurnProvider;
        TeleportationProvider m_TeleportationProvider;
        ContinuousMoveProviderBase m_ContinuousMoveProvider;

        void Awake()
        {
            m_SnapTurnProviderBase = GetComponent<SnapTurnProviderBase>();
            m_ContinuousTurnProvider = GetComponent<ContinuousTurnProviderBase>();
            m_TeleportationProvider = GetComponent<TeleportationProvider>();
            m_ContinuousMoveProvider = GetComponent<ContinuousMoveProviderBase>();
        }

        void OnEnable()
        {
            m_TurnSettings.AddListener(ChangeTurnSettings);
            m_MovementSettings.AddListener(ChangeMovementSettings);
        }

        void OnDisable()
        {
            m_TurnSettings.RemoveListener(ChangeTurnSettings);
            m_MovementSettings.RemoveListener(ChangeMovementSettings);
        }

        void ChangeTurnSettings(bool eventValue)
        {
            if (eventValue)
            {
                m_ContinuousTurnProvider.enabled = false;
                m_SnapTurnProviderBase.enabled = true;
            }
            else
            {
                m_ContinuousTurnProvider.enabled = true;
                m_SnapTurnProviderBase.enabled = false;
            }
        }

        void ChangeMovementSettings(bool eventValue)
        {
            if (eventValue)
            {
                m_ContinuousMoveProvider.enabled = false;
                m_TeleportationProvider.enabled = true;
            }
            else
            {
                m_ContinuousMoveProvider.enabled = true;
                m_TeleportationProvider.enabled = false;
            }
        }
    }
}
