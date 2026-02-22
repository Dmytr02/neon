using UnityEngine;

public class CatSceneStart : MonoBehaviour
{
    [SerializeField] GlobalLight globalLight;
    [SerializeField] GameObject postac;
    public void SetLight()
    {
        globalLight._intensity = 0;
        postac.SetActive(true);
        Destroy(this.gameObject);
    }
}
