using UnityEngine;

public class Corall : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject handCorallPrefab;
    public void Interact(Interactor interactor)
    {
        Transform corall = Instantiate(handCorallPrefab, transform.position, Quaternion.identity, interactor.handTransform).transform;
        
        corall.localPosition = Vector3.zero;
        corall.localRotation = Quaternion.identity;
        
        DeathController.Instance.handCorallPrefab = handCorallPrefab;
        DeathController.Instance.respPos = interactor.transform.position;
        
        Destroy(this);
    }
}
