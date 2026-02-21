using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] float interactDistance = 0.5f;
    [SerializeField] GameObject hint;
    public Transform handTransform;
    private void Update()
    {
        Collider2D[] overlap = Physics2D.OverlapCircleAll(transform.position, interactDistance, 1 << LayerMask.NameToLayer("Interactable"));
        IInteractable[] Interactables = overlap.Where(n => n.TryGetComponent(out IInteractable interactable)).Select(n => n.GetComponent<IInteractable>()).ToArray();
        if (Interactables.Length > 0)
        {   
            hint.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                foreach (IInteractable interactable in Interactables)
                {
                    interactable.Interact(this);
                }
            }
        }
        else
        {
            hint.SetActive(false);
        }
    }
}


interface IInteractable
{
    public void Interact(Interactor interactor);
}