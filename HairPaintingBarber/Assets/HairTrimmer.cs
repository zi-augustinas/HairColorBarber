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
    Transform m_TrimPoint;
    
    HairGrowerLogic m_HairGrowerLogic;
    bool m_ActivatingSpray;
    bool m_PickedUpHairSpray;

    bool m_TrimmerInHairRange;
    bool m_TrimmerActivated;

    LineRenderer rendere;
    void Start()
    {
        m_HairTrimLogic = new HairTrimLogic();
        rendere = GetComponent<LineRenderer>();
    }

    void OnEnable()
    {
        m_TrimmerActivatedEvent.AddListener(value =>m_TrimmerActivated = value);
    }

    // Update is called once per frame
    void Update()
    {  Debug.DrawLine(m_TrimPoint.position, m_TrimPoint.forward.normalized, Color.white, 2.5f);
        
        RaycastHit hit;
        var ray = new Ray(m_TrimPoint.position, m_TrimPoint.forward);
        Physics.Raycast(ray, out hit, 100);
        
        rendere.SetPosition(0,m_TrimPoint.position);
        rendere.SetPosition(1,hit.point);
        
        if (m_TrimmerActivated)
        {
            TrimHair();
        }
    }

    void TrimHair()
    {
        RaycastHit hit;
        var ray = new Ray(m_TrimPoint.position, m_TrimPoint.forward);
        Physics.Raycast(ray, out hit, 100);
        
        if(hit.transform!=null)
        {
            if ( Vector3.Distance(hit.point,transform.position)<0.5f && hit.transform.gameObject == m_HairObjectData.gameObject )
            {
                m_HairTrimLogic.SculptingEffect(hit.point,m_HairObjectData.objectWorldToMatrix,
                    m_HairObjectData.vertices,
                    m_HairObjectData.DefaultVertices,
                    m_HairObjectData.meshFilter,
                    m_HairObjectData.meshCollider);
            }
        }
    }


}
