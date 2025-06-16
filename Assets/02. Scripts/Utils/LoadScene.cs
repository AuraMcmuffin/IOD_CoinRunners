using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public GameObject howToPlayPanel; // Arrástralo en Inspector

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("sceneName no está seteada.");
        }
    }
  
    public void HowToPlayPanel()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("HowToPlay panel no está referenciado.");
        }
    }
  
    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("HowToPlay panel no está referenciado.");
        }
    }
}

