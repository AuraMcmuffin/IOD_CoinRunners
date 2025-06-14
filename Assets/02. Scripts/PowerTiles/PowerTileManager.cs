using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTileManager : MonoBehaviour
{
    private List<PowerTile> tiles;

    [SerializeField]
    private float interval = 5f;

    [SerializeField]
    private GameObject markerPrefab;

    [SerializeField]
    [Tooltip("Número máximo de tiles activas al mismo tiempo")]
    private int maxActiveTiles = 1;

    [SerializeField]
    [Tooltip("Tiempo que una tile permanece activa")]
    private float tileActiveDuration = 2f;

    private List<PowerTile> activeTiles = new List<PowerTile>();

    void Start()
    {
        tiles = new List<PowerTile>(FindObjectsOfType<PowerTile>());
        StartCoroutine(ActivateRandomTiles());
    }

    IEnumerator ActivateRandomTiles()
    {
        while (true)
        {
            while (activeTiles.Count < maxActiveTiles)
            {
                int idx = Random.Range(0, tiles.Count);
                var tile = tiles[idx];

                if (activeTiles.Contains(tile))
                    continue;

                var effectTypes = System.Enum.GetValues(typeof(PowerEffectType));
                tile.SetEffectType(
                    (PowerEffectType)effectTypes.GetValue(Random.Range(0, effectTypes.Length))
                );

                tile.Activate(markerPrefab);
                activeTiles.Add(tile);

                StartCoroutine(DeactivateTileAfterDuration(tile, tileActiveDuration));

                yield return new WaitForSeconds(interval);
            }

            yield return null;
        }
    }

    IEnumerator DeactivateTileAfterDuration(PowerTile tile, float duration)
    {
        yield return new WaitForSeconds(duration);
        tile.Deactivate();
        activeTiles.Remove(tile);
    }
}
