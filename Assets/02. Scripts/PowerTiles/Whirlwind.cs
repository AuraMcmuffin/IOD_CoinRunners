using UnityEngine;
using System.Collections;
public class Whirlwind : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float stunDuration = 3f;

    [SerializeField]
    private Vector3 direction = Vector3.forward;

    private IPowerEffect ConfusionEffect;

    public Animator PlayerAnimator;

    private void Awake()
    {
        ConfusionEffect = new ConfusionEffect();
    }

    private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pa asegurar que hay rose");
        var status = other.GetComponent<PlayerStatusEffects>();
        PlayerAnimator = other.GetComponentInChildren<Animator>();
        PlayerAnimator.SetTrigger("Confusion");
        if (status != null && ConfusionEffect != null)
        {
            ConfusionEffect.Apply(status, stunDuration);    
        }
    }
}
