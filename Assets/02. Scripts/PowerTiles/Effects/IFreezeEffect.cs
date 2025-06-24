using UnityEngine;

public class FreezeEffect : IPowerEffect
{
    public void Apply(PlayerStatusEffects triggeringPlayer, float duration)
    {
        PlayerStatusEffects[] allPlayers = GameObject.FindObjectsOfType<PlayerStatusEffects>();

        foreach (var player in allPlayers)
        {
            if (player != triggeringPlayer)
            {
                player.StartCoroutine(player.Freeze(duration));
                break; // solo congela a un rival
            }
        }
    }
}
