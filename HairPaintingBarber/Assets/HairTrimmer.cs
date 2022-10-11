using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairTrimmer : MonoBehaviour
{
    HairTrimLogic m_HairTrimLogic;
    [SerializeField]
    Bool_ScriptableObjectEvent m_TrimmerActivatedEvent;
    
    [SerializeField]
    GrowableHairObjectData m_HairObjectData;

    [SerializeField]
    Transform m_SprayPoint;
    
    HairGrowerLogic m_HairGrowerLogic;
    bool m_ActivatingSpray;
    bool m_PickedUpHairSpray;

    bool m_TrimmerInHairRange;
    bool m_TrimmerActivated;

    void Start()
    {
        m_HairTrimLogic = new HairTrimLogic();
    }

    void OnEnable()
    {
        m_TrimmerActivatedEvent.AddListener(value =>m_TrimmerActivated = value);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TrimmerActivated)
        {
            TrimHair();
        }
    }

    void TrimHair()
    {
        RaycastHit hit;
        var ray = new Ray(m_SprayPoint.position, m_SprayPoint.forward);
        Physics.Raycast(ray, out hit, 100);
        
        if(hit.transform!=null)
        {
            if ( Vector3.Distance(hit.point,transform.position)<0.3f && hit.transform.gameObject == m_HairObjectData.gameObject )
            {
                m_HairTrimLogic.SculptingEffect(hit.point,m_HairObjectData.objectWorldToMatrix,
                    m_HairObjectData.vertices,
                    m_HairObjectData.DefaultVertices,
                    m_HairObjectData.meshFilter,
                    m_HairObjectData.meshCollider);
            }
        }
    }

    void DistanceMeasure()
    {
       // if(Vector3.Distance(transform.position,))
    }
}
