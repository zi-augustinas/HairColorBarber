using UnityEngine;

public class HairGrowerLogic
{
    public void SculptingEffect(Vector3 point, Matrix4x4 objectWorldToMatrix, Vector3[] vertices, MeshFilter meshFilter, MeshCollider meshCollider, float brushSize)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertexPosition = objectWorldToMatrix.MultiplyPoint3x4(vertices[i]);

            if (Vector3.Distance(point, worldVertexPosition) < 0.1f)
            {
                vertices[i].x = Mathf.Lerp(vertices[i].x, vertices[i].x * 1.1f, Time.deltaTime * 5);
                vertices[i].y = Mathf.Lerp(vertices[i].y, vertices[i].y * 1.1f, Time.deltaTime * 5);
                vertices[i].z = Mathf.Lerp(vertices[i].z, vertices[i].z * 1.1f, Time.deltaTime * 5);
            }
        }
        meshFilter.mesh.vertices = vertices;
    }

}
