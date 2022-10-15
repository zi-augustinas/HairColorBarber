using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Bool_ScriptableObjectEvent m_JobsDone;
    [SerializeField]
    GrowableHairObjectData m_HairObjectData;
    [SerializeField]
    PaintSurface m_PaintSurface;

    void OnDisable()
    {
        m_JobsDone.AddListener(DisableHair);
    }

    void DisableHair(bool value)
    {
        m_HairObjectData.enabled = value;
        m_PaintSurface.enabled = value;
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
