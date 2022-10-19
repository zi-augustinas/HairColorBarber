using System;
using UnityEngine;

namespace VertexModifier
{
    public class SculptingEffect
    {
        Vector3 worldVertexPosition;

        public void SculptExpand(Vector3[] vertices, Transform hitTransform, Vector3 hitVertexWorldPosition, MeshFilter meshFilter)
        {
            for (var i = 0; i < vertices.Length; i++)
            {
                worldVertexPosition = hitTransform.TransformPoint(vertices[i]);
                if (Vector3.Distance(hitVertexWorldPosition, worldVertexPosition) < 0.02f)
                {
                    vertices[i].x = Mathf.Lerp(vertices[i].x, vertices[i].x * 1.05f, Time.deltaTime * 10f);
                    vertices[i].y = Mathf.Lerp(vertices[i].y, vertices[i].y * 1.05f, Time.deltaTime * 10f);
                    vertices[i].z = Mathf.Lerp(vertices[i].z, vertices[i].z * 1.05f, Time.deltaTime * 10f);
                }
            }

            meshFilter.mesh.vertices = vertices;
            vertices = null;
        }
        
        public void SculptReduce(Vector3[] vertices, Transform hitTransform, Vector3 hitVertexWorldPosition, Vector3[] originalVertexPosition, MeshFilter meshFilter)
        {
            for (var i = 0; i < vertices.Length; i++)
            {
                worldVertexPosition = hitTransform.TransformPoint(vertices[i]);
                if (Vector3.Distance(hitVertexWorldPosition, worldVertexPosition) < 0.03f)
                {
                    vertices[i].x = Mathf.Lerp(vertices[i].x, originalVertexPosition[i].x * 0.75f, Time.deltaTime * 2);
                    vertices[i].y = Mathf.Lerp(vertices[i].y, originalVertexPosition[i].y * 0.75f, Time.deltaTime * 2);
                    vertices[i].z = Mathf.Lerp(vertices[i].z, originalVertexPosition[i].z * 0.75f, Time.deltaTime * 2);
                }
            }

            meshFilter.mesh.vertices = vertices;
            vertices = null;
        }
    }
}
