using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{
    [SerializeField] Image DeathPanel;
    [SerializeField] Interactor Interactor;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    public GameObject handCorallPrefab;
    public Vector2 respPos;
    
    public static DeathController Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this);
    }

    void Start()
    {
        respPos = transform.position;
    }

    public void Death()
    {
        Debug.Log("Death");
        StartCoroutine("DeathAnimation");
    }

    IEnumerator DeathAnimation()
    {
        Debug.Log("Death2");
        float timer = 0.5f;
        var color = DeathPanel.color;
        while (timer > 0)
        {
            color.a = 1-(timer / 0.5f);
            DeathPanel.color = color;
            
            timer -= Time.deltaTime;
            yield return null;
        }
        color.a = 1;
        DeathPanel.color = color;
        
        transform.position = respPos;
        

        foreach (HandCorall handCorall in GetComponentsInChildren<HandCorall>()) Destroy(handCorall.gameObject);
        
        Transform corall = Instantiate(handCorallPrefab, transform.position, Quaternion.identity, Interactor.handTransform).transform;
        
        corall.localPosition = Vector3.zero;
        corall.localRotation = Quaternion.identity;
        
        timer = 0.5f;
        while (timer > 0)
        {
            color.a = timer / 0.5f;
            DeathPanel.color = color;
            
            timer -= Time.deltaTime;
            yield return null;
        }
        color.a = 0;
        DeathPanel.color = color;
        audioSource.PlayOneShot(audioClip);
    }
}
