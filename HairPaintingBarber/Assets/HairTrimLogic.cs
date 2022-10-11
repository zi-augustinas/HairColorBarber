using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairTrimLogic 
{

    public void SculptingEffect(Vector3 point, Matrix4x4 objectWorldToMatrix, Vector3[] vertices,Vector3[] originalVertexPosition, MeshFilter meshFilter, MeshCollider meshCollider)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertexPosition = objectWorldToMatrix.MultiplyPoint3x4(vertices[i]);

            if (Vector3.Distance(point, worldVertexPosition) < 0.05f)
            {
                    Debug.Log(vertices[i].x+" "+ originalVertexPosition[i].x);
                    Debug.Log(vertices[i].y+" "+ originalVertexPosition[i].y);
                    Debug.Log(vertices[i].z+" "+ originalVertexPosition[i].z);
                vertices[i].x = Mathf.Lerp(vertices[i].x, originalVertexPosition[i].x, Time.deltaTime * 5);
                vertices[i].y = Mathf.Lerp(vertices[i].y, originalVertexPosition[i].y, Time.deltaTime * 5);
                vertices[i].z = Mathf.Lerp(vertices[i].z, originalVertexPosition[i].z, Time.deltaTime * 5);
                
            }
        }
        meshFilter.mesh.vertices = vertices;
    }
}
