using System;
using UnityEngine;

namespace PixelColourChanger
{
    public class ColourSprayLogic
    {
        double PI = 3.1415926535;
        double angle, x1, y1;
        Color[] colours;

        // Start is called before the first frame update
        public void PixelColouring(Vector2 pixelUV, int size, float hardness, Color col, Texture2D tex)
        {
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            for (var i = 0; i < 360; i += 30)
            {
                angle = i;
                x1 = size * Math.Cos(angle * PI / 180);
                y1 = size * Math.Sin(angle * PI / 180);

                var realx = pixelUV.x + x1;
                var realy = pixelUV.y + y1;

                colours = tex.GetPixels((int) realx, (int) realy, size, size);

                for (var j = 0; j < size * size; j++) colours[j] = Color.Lerp(colours[j], col, Mathf.Lerp(hardness / 2, hardness * 2, hardness));

                tex.SetPixels((int) realx, (int) realy, size, size, colours);
                colours = null;
            }

            colours = tex.GetPixels((int) pixelUV.x, (int) pixelUV.y, (int) (size / 0.7f), (int) (size / 0.7f));

            for (var i = 0; i < (int) (size / 0.7f) * (int) (size / 0.7f); i++) colours[i] = Color.Lerp(colours[i], col, hardness * 5);

            tex.SetPixels((int) pixelUV.x, (int) pixelUV.y, (int) (size / 0.7f), (int) (size / 0.7f), colours);
            colours = null;
            tex.Apply();
        }
    }
}
