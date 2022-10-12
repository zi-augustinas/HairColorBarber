using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayPaint : MonoBehaviour
{

    [SerializeField]
    PaintSurface m_PaintSurface;
    
    [SerializeField]
    ColourSprayLogic m_SprayLogic;
    
    double PI = 3.1415926535;
    public Color col;
 
    [SerializeField]
    [Range(1f, 100f)]
    int size;
    [SerializeField]
    [Range(0f, 1f)]
    float hardness;

    [SerializeField]
    Transform m_SprayPoint;

    bool m_Paint=false;

    

    // Start is called before the first frame update
    void Start()
    {
        m_SprayLogic = new ColourSprayLogic();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Paint)
            SprayThePaint();
    }
    public void Activate()
    {
        
        m_Paint = true;
    }

    public void Deactivating()
    {
        m_Paint = false;
    }

    public void SprayThePaint()
    {
        RaycastHit hit;
        Ray ray = new Ray(m_SprayPoint.position,m_SprayPoint.forward); 

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject != null && m_PaintSurface.gameObject==hit.transform.gameObject)
            {
                m_SprayLogic.PixelColouring(hit.textureCoord,size,hardness,col,m_PaintSurface.texture2D);
                
            }
        }
    }

  
}
