using System;
using UnityEngine;
using VertexModifier;

namespace HairBarber
{
    public class HairTrimmer : MonoBehaviour
    {
        [SerializeField]
        GrowableHairObjectData m_HairObjectData;

        [SerializeField]
        Transform m_TrimPoint;

        HairTrimLogic m_HairTrimLogic;
        bool m_TrimmerActivated;
        int m_HairMask;

        void Start()
        {
            m_HairTrimLogic = new HairTrimLogic();
            m_HairMask = LayerMask.GetMask("Hair");
        }

        public void SetTrimmerActivationValue(bool isActive)
        {
            m_TrimmerActivated = isActive;
        }
        
        void Update()
        {
            if (m_TrimmerActivated) TrimHair();
        }

        void TrimHair()
        {
            RaycastHit hit;
            var ray = new Ray(m_TrimPoint.position, m_TrimPoint.forward);
            Physics.Raycast(ray, out hit, 0.1f, m_HairMask);

            if (hit.transform != null)
            {
                var hitTransform = hit.transform;
                var hitVertex = m_HairObjectData.vertices[m_HairObjectData.Triangles[hit.triangleIndex * 3 + 0]];
                hitVertex = hitTransform.TransformPoint(hitVertex);
                m_HairTrimLogic.SculptingEffect(m_HairObjectData.vertices, hitTransform, hitVertex, m_HairObjectData.DefaultVertices, m_HairObjectData.meshFilter);
            }
        }
    }
}
