using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class DirectButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;

    private float ymin = 0.0f;
    private float ymax = 0.0f;
    private bool previousPress = false;


    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hover = null;

    protected override void Awake ()
    {
        base.Awake();
        onHoverEnter.AddListener(StartPress);
        onHoverExit.AddListener(EndPress);
    }

    private void OnDestroy()
    {
        onHoverEnter.RemoveListener(StartPress);
        onHoverExit.RemoveListener(EndPress);

    }

    private void StartPress(XRBaseInteractor interactor)
    {
        hover = interactor;
        previousHandHeight = GetLocalYPosition(hover.transform.position);
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        hover = null;
        previousHandHeight = 0.0f;

        previousPress = false;
        SetYPosition(ymax);
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        ymin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        ymax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(hover)
        {
            float newHandHeight = GetLocalYPosition(hover.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);
        return localPosition.y;
    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, ymin, ymax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = Inposition();

        if (inPosition && inPosition != previousPress)
            OnPress.Invoke();

        previousPress = inPosition;
    }

    private bool Inposition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, ymin, ymin + 0.01f);

        return transform.localPosition.y == inRange;
    }
}
