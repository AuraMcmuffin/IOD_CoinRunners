using UnityEngine;

public class ManagerDios : MonoBehaviour
{
     [SerializeField] private Animator animator;

    private void OnEnable()
    {
        GameTimer.OnPreparationEnded += HandlePreparationEnded;
        GameTimer.OnTimerEnded += HandleGameEnded;
    }
    private void OnDisable()
    {
        GameTimer.OnPreparationEnded -= HandlePreparationEnded;
        GameTimer.OnTimerEnded -= HandleGameEnded;
    }
  
    private void Start()
    {
        // Al inicio el dios ataca directamente
        animator.SetTrigger("Attack_action");

        // Asegúrate en el Animator que, cuando termine Attack, vuelva automáticamente a idle de pie
    }
  
    private void HandlePreparationEnded()
    {
        // Cuando termine la preparación, el Dios se sienta
        animator.SetBool("IsSitting", true);
    }
  
    private void HandleGameEnded()
    {
        // Cuando termine el juego podemos dejar al Dios como queramos, en este ejemplo deja de estar sentado
        animator.SetBool("IsSitting", false);
    }
}