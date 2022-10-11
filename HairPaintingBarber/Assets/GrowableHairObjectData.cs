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
   public Vector3[] DefaultVertices;
   public MeshFilter meshFilter;
   public MeshCollider meshCollider;
   
   void Awake()
    {
        objectWorldToMatrix=transform.localToWorldMatrix;
        vertices = meshFilter.mesh.vertices;
        DefaultVertices = vertices;
    }

    public void RecalculateCollider() // Call this from editor when deactivating hairSpray
    {
        meshCollider.sharedMesh = meshFilter.sharedMesh;
    }
}
