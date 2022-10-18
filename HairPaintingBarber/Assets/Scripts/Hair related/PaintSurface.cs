using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PaintSurface : MonoBehaviour
{
    [SerializeField]
    Texture m_MainTexture;

    Texture TextureClone;
    
    [HideInInspector]
    public Texture2D texture2D;

   
    
    void Start()
    {
        var mainTexture = Instantiate(m_MainTexture);
        var currentTexture = GetComponent<Renderer>().material.mainTexture;
        if (currentTexture == null)
        {
            GetComponent<Renderer>().material.mainTexture=mainTexture;
        }

        TextureClone = GetComponent<Renderer>().material.mainTexture;
        texture2D = TextureClone as Texture2D;
    }
    
}
