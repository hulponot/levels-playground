using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.scripts.Interfaces;

public class InteractableWithRaycast : MonoBehaviour
{
    public Camera cam;
    public GameObject CurrentTarget { get; private set; }
    private int interactionLayer = 1 << 8;

    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f, interactionLayer))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = hit.transform.gameObject;
                enableCanvasChild(CurrentTarget, true);
            }
        }
        else
        {
            if (CurrentTarget != null)
            {
                enableCanvasChild(CurrentTarget, false);
                CurrentTarget = null;
            }
        }
    }

    private void enableCanvasChild(GameObject btn, bool active)
    {
        var interactable = btn.transform.GetComponent<IInteractableCorutine>();
        if (interactable != null)
        {
            if (active)
            {
                StartCoroutine(interactable.StartInteract());
            }
            else
            {
                StartCoroutine(interactable.StopInteract());
            }
            
        }


    }
}
