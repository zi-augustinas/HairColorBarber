using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayPaint : MonoBehaviour
{

 
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Paint)
            SprayThePaint();
    }

    public void selectingstuff()
    {
        Debug.Log("selecting");
    }

    public void Activate()
    {
        Debug.Log("Activating");
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
            if (hit.transform.gameObject != null)
            {
               Debug.Log(hit.transform.name); 
                PixelColouring(hit);
            }
        }
    }

    void PixelColouring(  RaycastHit hit)
        {
            Renderer rend = hit.transform.GetComponent<Renderer>();
            
            Texture2D tex = rend.material.mainTexture as Texture2D;
              
              Vector2 pixelUV = hit.textureCoord;
              Debug.Log(pixelUV);
              pixelUV.x *= tex.width;
              pixelUV.y *= tex.height;
              
            
            double  angle, x1=0, y1=0; 
            
            for(int i = 0; i < 360; i += 30)
            {
                angle = i;
                x1 = size * Math.Cos(angle * PI / 180);
                y1 = size * Math.Sin(angle * PI / 180);
                
                var realx = pixelUV.x + x1;
                var realy = pixelUV.y + y1;
    
                var test = tex.GetPixels((int) realx, (int) realy, size, size);
                for (int j = 0; j <  size*size; j++)
                {
                    test[j] = Color.Lerp(test[j], col, Mathf.Lerp(hardness/2,hardness*2,hardness));      
                }
                
                tex.SetPixels((int)realx, (int)realy, size, size,test);
            }
            
            for(int i = 0; i < 360; i += 30)
            {
                angle = i;
                x1 = size/2 * Math.Cos(angle * PI / 180);
                y1 = size/2 * Math.Sin(angle * PI / 180);
                
                var realx = pixelUV.x + x1+size/4;
                var realy = pixelUV.y + y1+size/4;
            
                var test = tex.GetPixels((int) realx, (int) realy, (int)(size/2), (int)(size/2));
                for (int j = 0; j <  (int)((int)(size/2)*(int)(size/2)); j++)
                {
                    test[j] = Color.Lerp(test[j], col, Mathf.Lerp(hardness*2,hardness*5,hardness));      
                }
                
                tex.SetPixels((int)realx, (int)realy, (int)size/2, (int)size/2,test);
            }
            
            
            var middlePixels = tex.GetPixels((int)(pixelUV.x), (int) pixelUV.y, (int)(size/0.7f), (int)(size/0.7f));
            for (int i = 0; i < (int)(size/0.7f)*(int)(size/0.7f); i++)
            {
                middlePixels[i] = Color.Lerp(middlePixels[i], col, hardness*5);
            }
            tex.SetPixels((int)(pixelUV.x),(int) pixelUV.y,(int)(size/0.7f), (int)(size/0.7f),middlePixels);
            
            tex.Apply();
             
            }
}
