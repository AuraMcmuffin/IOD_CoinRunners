using UnityEngine;

public class CrowdBounce : MonoBehaviour
{
    public float amplitude = 0.1f;      // Qué tanto se mueven arriba/abajo
    public float frequency = 1f;        // Qué tan rápido se mueven

    private float randomOffset;         // Para que cada uno tenga su propio ritmo
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // Fase aleatoria
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * frequency + randomOffset) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
