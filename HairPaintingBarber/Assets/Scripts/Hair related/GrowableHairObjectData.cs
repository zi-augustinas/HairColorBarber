using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowableHairObjectData : MonoBehaviour
{ 
   [SerializeField] 
    Bool_ScriptableObjectEvent m_JobsDone;
    
   [HideInInspector]
   public Matrix4x4 objectWorldToMatrix;
   [HideInInspector]
   public Vector3[] vertices;
   [HideInInspector]
   public Vector3[] DefaultVertices;  // This is for hair trimmer 
   public MeshFilter meshFilter;
   public MeshCollider meshCollider;
   public int[] Triangles;

   void OnEnable()
   {
       m_JobsDone.AddListener(DisableMeshCollider);
   }
   
   void OnDisable()
   {
       m_JobsDone.RemoveListener(DisableMeshCollider);
   }

   void Awake()
   {
       Triangles = meshFilter.mesh.triangles;
        objectWorldToMatrix=transform.localToWorldMatrix;
        vertices = meshFilter.mesh.vertices;
        DefaultVertices = new Vector3[vertices.Length];
        Array.Copy(vertices,DefaultVertices,vertices.Length);
    }

    public void RecalculateCollider() 
    {
        meshCollider.sharedMesh = meshFilter.sharedMesh;
    }
    void DisableMeshCollider(bool eventValue)
    {
        meshCollider.enabled = !eventValue;
    }
}
