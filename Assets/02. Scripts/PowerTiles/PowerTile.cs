using UnityEngine;

public enum PowerEffectType
{
    SpeedUp,
    SlowDown,
    InvertControls,
}

[System.Serializable]
public struct PowerEffectMaterial
{
    public PowerEffectType effectType;
    public Material material;
}

public static class PowerEffectFactory
{
    public static IPowerEffect Create(PowerEffectType type)
    {
        switch (type)
        {
            case PowerEffectType.SpeedUp:
                return new SpeedUpEffect();
            case PowerEffectType.SlowDown:
                return new SlowDownEffect();
            case PowerEffectType.InvertControls:
                return new InvertControlsEffect();
            default:
                return null;
        }
    }
}

public class PowerTile : MonoBehaviour
{
    [SerializeField]
    private float effectDuration = 2f;

    private PowerEffectType effectType;

    [Header("Referencia global de materiales por efecto")]
    public PowerEffectMaterialDatabase materialDatabase;
    private GameObject PowerTileInstasnce;

    public void Activate(GameObject markerPrefab)
    {
        if (PowerTileInstasnce == null && markerPrefab != null)
        {
            PowerTileInstasnce = Instantiate(
                markerPrefab,
                transform.position + Vector3.up * 0.1f,
                transform.rotation,
                transform
            );

            if (materialDatabase != null)
            {
                var markerRenderer = PowerTileInstasnce.GetComponent<Renderer>();
                var effectMat = materialDatabase.GetMaterial(effectType);
                if (markerRenderer != null && effectMat != null)
                {
                    markerRenderer.material = effectMat;
                }
            }

            var marker = PowerTileInstasnce.GetComponent<PowerTileMarker>();
            if (marker != null)
            {
                marker.Initialize(effectType, effectDuration, materialDatabase);
            }
        }
    }

    public void Deactivate()
    {
        if (PowerTileInstasnce != null)
        {
            Destroy(PowerTileInstasnce);
            PowerTileInstasnce = null;
        }
    }

    public void SetEffectType(PowerEffectType type)
    {
        effectType = type;
    }
}
