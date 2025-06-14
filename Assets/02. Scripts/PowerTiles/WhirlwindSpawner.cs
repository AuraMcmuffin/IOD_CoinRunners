using System.Collections;
using UnityEngine;

public class WhirlwindSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject whirlwindPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float cooldown = 5f;

    [SerializeField]
    private float startDelay = 20f;

    private bool whirlwindActive = false;

    private void Start()
    {
        StartCoroutine(WhirlwindRoutine());
    }

    IEnumerator WhirlwindRoutine()
    {
        while (!GameTimer.instance.GameRunning)
            yield return null;
        yield return new WaitForSeconds(startDelay);

        while (GameTimer.instance.GameRunning)
        {
            if (!whirlwindActive)
            {
                SpawnWhirlwind();
            }
            yield return new WaitForSeconds(cooldown);
        }
    }

    void SpawnWhirlwind()
    {
        int idx = Random.Range(0, spawnPoints.Length);
        var spawn = spawnPoints[idx];
        var whirlwind = Instantiate(whirlwindPrefab, spawn.position, spawn.rotation);
        whirlwindActive = true;
        StartCoroutine(WaitAndReset(whirlwind));
    }

    IEnumerator WaitAndReset(GameObject whirlwind)
    {
        // Espera a que el torbellino salga de la escena o destrúyelo tras X segundos
        yield return new WaitForSeconds(8f); // o el tiempo que dure en pantalla
        Destroy(whirlwind);
        whirlwindActive = false;
    }
}
