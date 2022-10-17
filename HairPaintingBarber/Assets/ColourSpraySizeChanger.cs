using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColourSpraySizeChanger : XRBaseInteractable
{
   protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        args.interactorObject.transform.GetComponent<XRRayInteractor>().allowHoveredActivate = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        args.interactorObject.transform.GetComponent<XRRayInteractor>().allowHoveredActivate = false;
    }
}
