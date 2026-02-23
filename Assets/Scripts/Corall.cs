using UnityEngine;

public class Corall : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject handCorallPrefab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    public void Interact(Interactor interactor)
    {
        foreach (var i in interactor.GetComponentsInChildren<HandCorall>())
        {
            Destroy(i.gameObject);
        }
        
        Transform corall = Instantiate(handCorallPrefab, transform.position, Quaternion.identity, interactor.handTransform).transform;
        
        corall.localPosition = Vector3.zero;
        corall.localRotation = Quaternion.identity;
        
        DeathController.Instance.handCorallPrefab = handCorallPrefab;
        DeathController.Instance.respPos = interactor.transform.position;
        audioSource.PlayOneShot(audioClip);
        
        Destroy(this);
    }
}
