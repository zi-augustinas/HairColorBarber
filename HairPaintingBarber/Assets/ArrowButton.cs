using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class ArrowButton :  XRBaseInteractable
{
    [SerializeField]
    Transform m_ChairTransform;

    Vector3 m_ChairOriginalPosition;
    Vector3 m_ChairMaximumPosition;

    bool m_LiftTheChair;
    bool m_LowerTheChair;
    

    void Start()
    {
        m_LiftTheChair = false;
        m_LowerTheChair = false;
        m_ChairOriginalPosition = m_ChairTransform.position;
        m_ChairMaximumPosition = m_ChairTransform.position + Vector3.up * 0.25f;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        args.interactorObject.transform.GetComponent<XRRayInteractor>().allowHoveredActivate = true;
        args.interactorObject.transform.GetComponent<XRRayInteractor>().hideControllerOnSelect = false;

    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        args.interactorObject.transform.GetComponent<XRRayInteractor>().allowHoveredActivate = false;
        args.interactorObject.transform.GetComponent<XRRayInteractor>().hideControllerOnSelect = true;

        DeActivate();
    }
    

    void Update()
    {
        if (m_LiftTheChair)
        {
            ChangeChairsPosition(m_ChairMaximumPosition);
        }

        if (m_LowerTheChair)
        {
            ChangeChairsPosition(m_ChairOriginalPosition);
        }
    }

    void ChangeChairsPosition(Vector3 destination)
    {
        if (Vector3.Distance(m_ChairTransform.position, destination) > 0.01f)
        {
            m_ChairTransform.position = Vector3.Lerp(m_ChairTransform.position, destination, Time.deltaTime);
        }
    }

    public void LiftTheChair()
    {
        m_LiftTheChair = true;
    }

    public void LowerTheChair()
    {
        m_LowerTheChair = true;
    }
    public void DeActivate()
    {
        m_LiftTheChair = false;
        m_LowerTheChair = false;
    }

}
