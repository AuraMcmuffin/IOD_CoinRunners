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

    private void Awake()
    {
        CurrentSpeed = baseSpeed;
        ControlsInverted = false;
    }

    public IEnumerator Freeze(float duration)
    {
        if (isFreezeActive)
            yield break;
        isFreezeActive = true;
        float prev = CurrentSpeed;
        CurrentSpeed = 0;
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isFreezeActive = false;
    }

    public IEnumerator SpeedUp(float duration)
    {
        if (isSpeedUpActive)
            yield break;
        isSpeedUpActive = true;
        float prev = CurrentSpeed;
        CurrentSpeed = baseSpeed * 2f;
        PlayerAnimator.SetBool("IsRunning", true);
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isSpeedUpActive = false;
        PlayerAnimator.SetBool("IsRunning", false);
    }

    public IEnumerator SlowDown(float duration)
    {
        if (isSlowDownActive)
            yield break;
        isSlowDownActive = true;
        float prev = CurrentSpeed;
        CurrentSpeed = baseSpeed * 0.5f;
        yield return new WaitForSeconds(duration);
        CurrentSpeed = prev;
        isSlowDownActive = false;
    }

    public IEnumerator InvertControls(float duration)
    {
        if (isInvertControlsActive)
            yield break;
        isInvertControlsActive = true;
        ControlsInverted = true;
        yield return new WaitForSeconds(duration);
        ControlsInverted = false;
        isInvertControlsActive = false;
    }
}
