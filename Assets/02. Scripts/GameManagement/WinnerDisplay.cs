using UnityEngine;

public class WinnerDisplay : MonoBehaviour
{
    [Tooltip("Lista de prefabs disponibles, deben coincidir con los nombres")]
    public GameObject[] playerPrefabs;

    void Start()
    {
        string winnerName = GameData.WinnerPrefabName;

        foreach (GameObject prefab in playerPrefabs)
        {
            if (prefab.name == winnerName)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("No se encontró el prefab del ganador con nombre: " + winnerName);
    }
}
