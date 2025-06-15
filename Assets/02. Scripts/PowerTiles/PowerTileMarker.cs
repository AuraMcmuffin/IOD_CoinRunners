using UnityEngine;

public class PowerTileMarker : MonoBehaviour
{
    private PowerEffectType effectType;
    private float effectDuration;
    private PowerEffectMaterialDatabase materialDatabase;

    public void Initialize(PowerEffectType type, float duration, PowerEffectMaterialDatabase db)
    {
        effectType = type;
        effectDuration = duration;
        materialDatabase = db;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Colisión con el jugador");

        var statusEffects = other.GetComponent<PlayerStatusEffects>();
        IPowerEffect effect = PowerEffectFactory.Create(effectType);
        if (statusEffects != null && effect != null)
        {
            effect.Apply(statusEffects, effectDuration);
        }
    }
}
