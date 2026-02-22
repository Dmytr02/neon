using UnityEngine;

public class Algae : MonoBehaviour, IInteractable
{
    [SerializeField] HandAlgae HandAlgaePrefab;
    bool isInteracting = true;
    public void Interact(Interactor interactor)
    {
        if(!isInteracting) return;
        HandAlgae handAlgae = Instantiate(HandAlgaePrefab, transform.position, transform.rotation, interactor.transform);
        
        handAlgae.transform.localPosition = Vector3.zero;
        handAlgae.transform.localRotation = Quaternion.identity;
        Destroy(this.gameObject);
        
        isInteracting = false;
        
        Invoke("CanInteract", 30);
        
        foreach (var i in GetComponentsInChildren<Renderer>())
        {
            i.enabled = false;
        }
    }

    void CanInteract()
    {
        bool isInteracting = true;
        foreach (var i in GetComponentsInChildren<Renderer>())
        {
            i.enabled = true;
        }
    }
}
