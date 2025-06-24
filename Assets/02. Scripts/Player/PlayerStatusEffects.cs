using System.Collections;
using UnityEngine;

public class PlayerStatusEffects : MonoBehaviour
{

    public Animator PlayerAnimator;

    [SerializeField]
    private float baseSpeed = 5f;
    public float CurrentSpeed { get; private set; }
    public bool ControlsInverted { get; private set; }

    private bool isFreezeActive = false;
    private bool isSpeedUpActive = false;
    private bool isSlowDownActive = false;
    private bool isInvertControlsActive = false;
    private bool isConfusedActive = false;


    private void Awake()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        CurrentSpeed = baseSpeed;
        ControlsInverted = false;
    }

    public IEnumerator Confusion(float duration)
    {
        if (isConfusedActive)
            yield break;
        isFreezeActive = true;
        float prev = CurrentSpeed;
        IconManager.Instance.ActivarIconoConfusion();
        CurrentSpeed = 0;
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isConfusedActive = false;
        IconManager.Instance.DesactivarIconoConfusion();
    }

    public IEnumerator Freeze(float duration)
    {
        if (isFreezeActive)
            yield break;
        isFreezeActive = true;
        float prev = CurrentSpeed;
        IconManager.Instance.ActivarIconoFreeze();
        CurrentSpeed = 0;
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isFreezeActive = false;
        IconManager.Instance.DesactivarIconoFreeze();
    }

    public IEnumerator SpeedUp(float duration)
    {
        if (isSpeedUpActive)
            yield break;
        isSpeedUpActive = true;
        float prev = CurrentSpeed;
        IconManager.Instance.ActivarIconoSpeed();
        CurrentSpeed = baseSpeed * 2f;
        PlayerAnimator.SetBool("IsRunning", true);
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isSpeedUpActive = false;
        PlayerAnimator.SetBool("IsRunning", false);
        IconManager.Instance.DesactivarIconoSpeed();
    }

    public IEnumerator SlowDown(float duration)
    {
        Debug.Log("SlowDownFunction");
        if (isSlowDownActive)
            yield break;
        isSlowDownActive = true;
        IconManager.Instance.ActivarIconoSlow();
        float prev = CurrentSpeed;
        CurrentSpeed = baseSpeed * 0.3f;
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isSlowDownActive = false;
        IconManager.Instance.DesactivarIconoSlow();
    }

    public IEnumerator InvertControls(float duration)
    {
        if (isInvertControlsActive)
            yield break;
        isInvertControlsActive = true;
        IconManager.Instance.ActivarIconoInvert();
        ControlsInverted = true;
        yield return new WaitForSeconds(duration);
        ControlsInverted = false;
        isInvertControlsActive = false;
        IconManager.Instance.DesactivarIconoInvert();
    }
}
