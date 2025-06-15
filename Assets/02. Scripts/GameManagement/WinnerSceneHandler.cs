using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerSceneHandler : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject winnerText;

    private void Start()
    {
        if (GameResultManager.Instance != null && GameResultManager.Instance.WinnerPrefab != null)
        {
            Instantiate(GameResultManager.Instance.WinnerPrefab, spawnPoint.position, Quaternion.identity);
        }

        winnerText.SetActive(true); // Mostrar "GANADOR"
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
