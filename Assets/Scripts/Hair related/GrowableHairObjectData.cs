using System;
using ScriptableObjectEvent;
using UnityEngine;

namespace HairBarber
{
    public class GrowableHairObjectData : MonoBehaviour
    {
        [HideInInspector]
        public Vector3[] vertices;
        [HideInInspector]
        public Vector3[] DefaultVertices; 
        public MeshFilter meshFilter;
        public MeshCollider meshCollider;
        public int[] Triangles;
        
        [SerializeField]
        Bool_ScriptableObjectEvent m_JobsDone;

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
            vertices = meshFilter.mesh.vertices;
            DefaultVertices = new Vector3[vertices.Length];
            Array.Copy(vertices, DefaultVertices, vertices.Length);
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
}
