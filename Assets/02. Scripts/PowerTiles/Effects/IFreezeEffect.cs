using UnityEngine;

public class FreezeEffect : IPowerEffect
{
    public void Apply(PlayerStatusEffects triggeringPlayer, float duration)
    {
        PlayerStatusEffects[] allPlayers = GameObject.FindObjectsOfType<PlayerStatusEffects>();

        foreach (var player in allPlayers)
        {
            Debug.Log($"Encontrado jugador: {player.name}");
            if (player != triggeringPlayer)
            {
                Debug.Log($"Aplicando congelación a {player.name}");
                player.StartCoroutine(player.Freeze(duration));
                break; // solo congela a un rival
            }
        }
    }
}
