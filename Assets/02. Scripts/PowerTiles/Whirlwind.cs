using UnityEngine;

public class Whirlwind : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float stunDuration = 3f;

    [SerializeField]
    private Vector3 direction = Vector3.forward;

    private IPowerEffect _freezeEffect;

    public Animator PlayerAnimator;

    private void Awake()
    {
        _freezeEffect = new FreezeEffect();
    }

    private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var status = other.GetComponent<PlayerStatusEffects>();
        if (status != null && _freezeEffect != null)
        {
            _freezeEffect.Apply(status, stunDuration);
            PlayerAnimator.SetTrigger("Confusion");
        }
    }
}
