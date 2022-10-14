using System;
using UnityEngine;

public class HairGrowerSpray : MonoBehaviour
{
    [SerializeField]
    GrowableHairObjectData m_HairObjectData;

    [SerializeField]
    float m_BrushSize;

    [SerializeField]
    Transform m_SprayPoint;

    HairGrowerLogic m_HairGrowerLogic;
    bool m_ActivatingSpray;
    bool m_PickedUpHairSpray;

    [SerializeField]
    Bool_ScriptableObjectEvent m_BrushSizeChangeEvent;

    [SerializeField]
    Bool_ScriptableObjectEvent m_HairSprayActivatedEvent;

    int m_HairMask;

    void OnEnable()
    {
        m_HairSprayActivatedEvent.AddListener(value => m_ActivatingSpray = value);
    }

    void Start()
    {
        m_HairGrowerLogic = new HairGrowerLogic();
        m_HairMask = LayerMask.GetMask("Hair");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ActivatingSpray) CheckIfHittingCorrectTarget();
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
            m_HairGrowerLogic.SculptingEffect(m_HairObjectData.vertices, hitTransform, hitVertex, m_HairObjectData.meshFilter, 1);
        }
    }
}
