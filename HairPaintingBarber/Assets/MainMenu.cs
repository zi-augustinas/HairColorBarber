using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenu : MonoBehaviour
{
    bool m_IsSnappingOn;
    bool m_IsTeleportOn;
    [SerializeField]
    TextMeshProUGUI m_TurningSettingsButtonText;
    
    [SerializeField]
    TextMeshProUGUI m_MovementSettingsButtonText;

    [SerializeField]
    Bool_ScriptableObjectEvent m_TurnSettings;
    
    [SerializeField]
    Bool_ScriptableObjectEvent m_MovementSettings;
    
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
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
