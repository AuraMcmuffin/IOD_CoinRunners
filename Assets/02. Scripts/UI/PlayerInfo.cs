using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public IconManager iconManager;  // asigna este en el inspector

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public void Activate(GameObject playerObject)
    {
        gameObject.SetActive(true);
        CoinObtainer coinObtainer = playerObject.GetComponent<CoinObtainer>();
        coinObtainer.OnCoinObtained += OnCoinObtained;

        // 🔽 Esta parte es clave:
        PlayerStatusEffects statusEffects = playerObject.GetComponent<PlayerStatusEffects>();
        IconManager iconManager = GetComponent<IconManager>();

        if (statusEffects != null && iconManager != null)
        {
            statusEffects.SetIconManager(iconManager);
        }
        else
        {
            Debug.LogWarning("No se pudo asignar el IconManager al jugador.");
        }
    }

    private void OnCoinObtained(int coins)
    {
        _scoreText.text = coins.ToString();
    }
}

