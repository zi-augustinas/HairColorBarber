using UnityEngine;

public class HairGrowerLogic
{
    Vector3 worldVertexPosition;
    public void SculptingEffect(Vector3 point, Matrix4x4 objectWorldToMatrix, Vector3[] vertices, MeshFilter meshFilter, MeshCollider meshCollider, float brushSize)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            worldVertexPosition = objectWorldToMatrix.MultiplyPoint3x4(vertices[i]);

            if (Vector3.Distance(point, worldVertexPosition) < 0.05f)
            {
                vertices[i].x = Mathf.Lerp(vertices[i].x, vertices[i].x * 1.05f, Time.deltaTime * 4);
                vertices[i].y = Mathf.Lerp(vertices[i].y, vertices[i].y * 1.05f, Time.deltaTime * 4);
                vertices[i].z = Mathf.Lerp(vertices[i].z, vertices[i].z * 1.05f, Time.deltaTime * 4);
            }
        }
        meshFilter.mesh.vertices = vertices;
        vertices = null;
    }

}
