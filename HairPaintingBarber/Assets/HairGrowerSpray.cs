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
    Bool_ScriptableObjectEvent m_HairSprayPickedupEvent;
    [SerializeField]
    Bool_ScriptableObjectEvent m_HairSprayActivatedEvent;

   

    void OnEnable()
    {
       // m_BrushSizeChangeEvent.AddListener();
       m_HairSprayPickedupEvent.AddListener(value=>m_PickedUpHairSpray = value);
       m_HairSprayActivatedEvent.AddListener(value =>m_ActivatingSpray = value);
       
        // subscribe to event when brush size is changed
        //subscribe to event when picked up hairSpray
        // subscrive to event when pressing spray button
    }

    void OnDisable()
    {
        // unsubscribe to event when brush size is changed
    }

    void Start()
    {
        m_HairGrowerLogic = new HairGrowerLogic();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PickedUpHairSpray)
        {
            CheckIfHittingCorrectTarget();
        }
    }

    void CheckIfHittingCorrectTarget()
    {
        RaycastHit hit;
        var ray = new Ray(m_SprayPoint.position, m_SprayPoint.forward);
        Physics.Raycast(ray, out hit, 100);

        if (hit.transform.gameObject == m_HairObjectData.gameObject)
            if (m_ActivatingSpray)
                m_HairGrowerLogic.SculptingEffect(hit.point,
                    m_HairObjectData.objectWorldToMatrix,
                    m_HairObjectData.vertices,
                    m_HairObjectData.DefaultVertices,
                    m_HairObjectData.meshFilter,
                    m_HairObjectData.meshCollider,
                    m_BrushSize);
    }
}
