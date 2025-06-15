using UnityEngine;

public class SlowDownEffect : IPowerEffect
{
    public void Apply(PlayerStatusEffects target, float duration)
    {
        Debug.Log("Aplicando efecto");
        target.StartCoroutine(target.SlowDown(duration));
    }
}
