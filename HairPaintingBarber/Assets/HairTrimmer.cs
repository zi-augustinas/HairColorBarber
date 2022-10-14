using System;
using UnityEngine;

public class HairTrimmer : MonoBehaviour
{
    
    [SerializeField]
    Bool_ScriptableObjectEvent m_TrimmerActivatedEvent;

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

    void OnEnable()
    {
        m_TrimmerActivatedEvent.AddListener(value => m_TrimmerActivated = value);
    }

    // Update is called once per frame
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
