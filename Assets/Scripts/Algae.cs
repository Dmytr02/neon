using UnityEngine;

public class Algae : MonoBehaviour, IInteractable
{
    [SerializeField] HandAlgae HandAlgaePrefab;
    public void Interact(Interactor interactor)
    {
        HandAlgae handAlgae = Instantiate(HandAlgaePrefab, transform.position, transform.rotation, interactor.transform);
        
        handAlgae.transform.localPosition = Vector3.zero;
        handAlgae.transform.localRotation = Quaternion.identity;
        Destroy(this.gameObject);
    }
}
