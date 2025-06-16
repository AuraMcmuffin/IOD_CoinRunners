public class ConfusionEffect : IPowerEffect
{
    public void Apply(PlayerStatusEffects target, float duration)
    {
        target.StartCoroutine(target.Confusion(duration));
    }
}
