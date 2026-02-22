using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
