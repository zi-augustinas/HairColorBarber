using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairTrimLogic
{
    Vector3 worldVertexPosition;
    
    public void SculptingEffect(Vector3[] vertices,Transform hitTransform,Vector3 hitVertexWorldPosition,Vector3[] originalVertexPosition, MeshFilter meshFilter)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            worldVertexPosition = hitTransform.TransformPoint(vertices[i]);
            if (Vector3.Distance(hitVertexWorldPosition, worldVertexPosition) < 0.03f)
            {
                
                vertices[i].x = Mathf.Lerp(vertices[i].x, originalVertexPosition[i].x*0.8f, Time.deltaTime*2);
                vertices[i].y = Mathf.Lerp(vertices[i].y, originalVertexPosition[i].y*0.8f, Time.deltaTime*2);
                vertices[i].z = Mathf.Lerp(vertices[i].z, originalVertexPosition[i].z*0.8f, Time.deltaTime*2);
            }
        }
        meshFilter.mesh.vertices = vertices;
        vertices = null;
    }
}
