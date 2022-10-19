using System;
using UnityEngine;
using VertexModifier;

namespace HairBarber
{
    public class HairGrowerSpray : MonoBehaviour
    {
        [SerializeField]
        GrowableHairObjectData m_HairObjectData;
        [SerializeField]
        Transform m_SprayPoint;

        SculptingEffect m_SculptingEffect;
        bool m_ActivatingSpray;
        bool m_PickedUpHairSpray;
        int m_HairMask;


        void Start()
        {
            m_SculptingEffect = new SculptingEffect();
            m_HairMask = LayerMask.GetMask("Hair");
        }
        
        void Update()
        {
            if (m_ActivatingSpray) CheckIfHittingCorrectTarget();
        }

        public void SetHairSprayActivationValue(bool isActive)
        {
            m_ActivatingSpray = isActive;
        }

        void CheckIfHittingCorrectTarget()
        {
            RaycastHit hit;
            Ray ray = new Ray(m_SprayPoint.position, m_SprayPoint.forward);
            Physics.Raycast(ray, out hit, 0.3f, m_HairMask);

            if (hit.transform != null)
            {
                Transform hitTransform = hit.transform;
                Vector3 hitVertex = m_HairObjectData.vertices[m_HairObjectData.Triangles[hit.triangleIndex * 3 + 0]];
                hitVertex = hitTransform.TransformPoint(hitVertex);
                m_SculptingEffect.SculptExpand(m_HairObjectData.vertices, hitTransform, hitVertex, m_HairObjectData.meshFilter);
            }
        }
    }
}
