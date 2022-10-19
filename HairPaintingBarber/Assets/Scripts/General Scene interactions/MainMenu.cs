using System;
using ScriptableObjectEvent;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HairBarber
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI m_TurningSettingsButtonText;

        [SerializeField]
        TextMeshProUGUI m_MovementSettingsButtonText;

        [SerializeField]
        Bool_ScriptableObjectEvent m_TurnSettings;

        [SerializeField]
        Bool_ScriptableObjectEvent m_MovementSettings;

        bool m_IsSnappingOn;
        bool m_IsTeleportOn;

        void Start()
        {
            m_IsSnappingOn = false;
            m_IsTeleportOn = false;
        }

        public void ChangeTurnSettings()
        {
            if (!m_IsSnappingOn)
            {
                m_TurningSettingsButtonText.text = "Enable Continues Turn";
                m_IsSnappingOn = true;
                m_TurnSettings.RaiseEvent(true);
            }
            else
            {
                m_TurningSettingsButtonText.text = "Enable Snap Turn";
                m_IsSnappingOn = false;
                m_TurnSettings.RaiseEvent(false);
            }
        }

        public void ChangeMovementSettings()
        {
            if (!m_IsTeleportOn)
            {
                m_MovementSettingsButtonText.text = "Enable Continues Movement";
                m_IsTeleportOn = true;
                m_MovementSettings.RaiseEvent(true);
            }
            else
            {
                m_MovementSettingsButtonText.text = "Enable Teleport";
                m_IsTeleportOn = false;
                m_MovementSettings.RaiseEvent(false);
            }
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
