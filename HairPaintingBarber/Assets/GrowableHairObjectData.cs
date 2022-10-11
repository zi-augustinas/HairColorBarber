using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowableHairObjectData : MonoBehaviour
{ 
   [HideInInspector]
   public Matrix4x4 objectWorldToMatrix;
   [HideInInspector]
   public Vector3[] vertices;
   [HideInInspector]
   public Vector3[] DefaultVertices;  // This is for hair trimmer 
   public MeshFilter meshFilter;
   public MeshCollider meshCollider;
   
   void Awake()
    {
        objectWorldToMatrix=transform.localToWorldMatrix;
        vertices = meshFilter.mesh.vertices;
        DefaultVertices = new Vector3[vertices.Length];
        Array.Copy(vertices,DefaultVertices,vertices.Length);
    }

    public void RecalculateCollider() 
    {
        meshCollider.sharedMesh = meshFilter.sharedMesh;
    }
}
