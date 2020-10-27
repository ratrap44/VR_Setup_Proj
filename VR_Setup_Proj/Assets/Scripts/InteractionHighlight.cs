using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionHighlight : MonoBehaviour
{

    public Material mat_Hover = null;
    public Material mat_Highlight = null;

    private Material mat_Original = null;
    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabObject = null;

    private void Awake()
    {
        mat_Original = GetComponent<Material>();
        meshRenderer = GetComponent<MeshRenderer>();
        grabObject = GetComponent<XRGrabInteractable>();

        grabObject.onActivate.AddListener(SetHighlight);
        grabObject.onDeactivate.AddListener(SetOriginal);
        grabObject.onHoverEnter.AddListener(SetHover);
        
    }
    private void OnDestroy()
    {
        grabObject.onActivate.RemoveListener(SetHighlight);
        grabObject.onDeactivate.RemoveListener(SetOriginal);
        grabObject.onDeactivate.RemoveListener(SetHover);
    }
    private void SetHover(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Hover;
    }

    private void SetOriginal(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Original;
    }

    private void SetHighlight(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Highlight;
    }
}
