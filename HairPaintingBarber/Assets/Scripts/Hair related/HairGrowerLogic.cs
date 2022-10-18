using UnityEngine;

public class HairGrowerLogic
{
    Vector3 worldVertexPosition;
    public void SculptingEffect(Vector3[] vertices, Transform hitTransform,Vector3 hitVertexWorldPosition, MeshFilter meshFilter)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            worldVertexPosition = hitTransform.TransformPoint(vertices[i]);
            if (Vector3.Distance(hitVertexWorldPosition, worldVertexPosition) < 0.02f)
            {
                vertices[i].x = Mathf.Lerp(vertices[i].x, vertices[i].x*1.05f, Time.deltaTime*10f);
                vertices[i].y = Mathf.Lerp(vertices[i].y, vertices[i].y*1.05f, Time.deltaTime*10f);
                vertices[i].z = Mathf.Lerp(vertices[i].z, vertices[i].z*1.05f, Time.deltaTime*10f);
            }
        }
        meshFilter.mesh.vertices = vertices;
        vertices = null;
    }

}
