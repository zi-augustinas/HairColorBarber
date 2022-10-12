using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSprayLogic 
{
    double PI = 3.1415926535;
    double  angle, x1, y1; 
    // Start is called before the first frame update
     public void PixelColouring(  Vector2 pixelUV, int size, float hardness,Color col, Texture2D tex)
        {
            pixelUV.x *= tex.width;
              pixelUV.y *= tex.height;

            for(int i = 0; i < 360; i += 30)
            {
                angle = i;
                x1 = size * Math.Cos(angle * PI / 180);
                y1 = size * Math.Sin(angle * PI / 180);
                
                var realx = pixelUV.x + x1;
                var realy = pixelUV.y + y1;
                
                
                
                var colors = tex.GetPixels((int) realx, (int) realy, size, size);
              
                for (int j = 0; j <  size*size; j++)
                {
                    colors[j] = Color.Lerp(colors[j], col, Mathf.Lerp(hardness/2,hardness*2,hardness));      
                }
                
                tex.SetPixels((int)realx, (int)realy, size, size,colors);
            }
            
            // for(int i = 0; i < 360; i += 30)
            // {
            //     angle = i;
            //     x1 = size/2 * Math.Cos(angle * PI / 180);
            //     y1 = size/2 * Math.Sin(angle * PI / 180);
            //     
            //     var realx = pixelUV.x + x1+size/4;
            //     var realy = pixelUV.y + y1+size/4;
            //
            //     var colors = tex.GetPixels((int) realx, (int) realy, (int)(size/2), (int)(size/2));
            //     
            //     for (int j = 0; j <  (int)((int)(size/2)*(int)(size/2)); j++)
            //     {
            //         colors[j] = Color.Lerp(colors[j], col, Mathf.Lerp(hardness*2,hardness*5,hardness));      
            //     }
            //     
            //     tex.SetPixels((int)realx, (int)realy, (int)size/2, (int)size/2,colors);
            // }
            //
            
            var middlePixelsColours = tex.GetPixels((int)(pixelUV.x), (int) pixelUV.y, (int)(size/0.7f), (int)(size/0.7f));
            
            for (int i = 0; i < (int)(size/0.7f)*(int)(size/0.7f); i++)
            {
                middlePixelsColours[i] = Color.Lerp(middlePixelsColours[i], col, hardness*5);
            }
            tex.SetPixels((int)(pixelUV.x),(int) pixelUV.y,(int)(size/0.7f), (int)(size/0.7f),middlePixelsColours);
            
            tex.Apply();
             
            }
}