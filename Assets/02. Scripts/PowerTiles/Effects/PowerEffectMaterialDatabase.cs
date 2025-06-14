using UnityEngine;

[CreateAssetMenu(menuName = "PowerTiles/PowerEffectMaterialDatabase")]
public class PowerEffectMaterialDatabase : ScriptableObject
{
    public PowerEffectMaterial[] effectMaterials;

    public Material GetMaterial(PowerEffectType type)
    {
        foreach (var entry in effectMaterials)
        {
            if (entry.effectType == type)
                return entry.material;
        }
        return null;
    }
}
