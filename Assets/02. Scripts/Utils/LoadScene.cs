using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public GameObject HTPPanel; // nombre de la escena que deseas cargar

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void HowToPlayPanel()
    {
        if (HTPPanel != null)
        {
            HTPPanel.SetActive(true);
        }
    }
  
    public void CloseHowToPlayPanel()
    {
        if (HTPPanel != null)
        {
            HTPPanel.SetActive(false);
        }
    }
}