using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairTrimLogic
{
    Vector3 worldVertexPosition;
    
    public void SculptingEffect(Vector3 point, Matrix4x4 objectWorldToMatrix, Vector3[] vertices,Vector3[] originalVertexPosition, MeshFilter meshFilter, MeshCollider meshCollider)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            worldVertexPosition = objectWorldToMatrix.MultiplyPoint3x4(vertices[i]);

            if (Vector3.Distance(point, worldVertexPosition) < 0.1f)
            {
                vertices[i].x = Mathf.Lerp(vertices[i].x, originalVertexPosition[i].x, 1);
                vertices[i].y = Mathf.Lerp(vertices[i].y, originalVertexPosition[i].y, 1);
                vertices[i].z = Mathf.Lerp(vertices[i].z, originalVertexPosition[i].z, 1);
            }
        }
        meshFilter.mesh.vertices = vertices;
        vertices = null;
        
    }
}
