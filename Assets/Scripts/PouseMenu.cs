using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    bool isGamePoused = false;
    [SerializeField] private GameObject pousePanel;
    public void Pouse()
    {
        if (isGamePoused)
        {
            Time.timeScale = 1;
            pousePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pousePanel.SetActive(true);
        }
        isGamePoused = !isGamePoused;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pouse();
        }
    }
}
