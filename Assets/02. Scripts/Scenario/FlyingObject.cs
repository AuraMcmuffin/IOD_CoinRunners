using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float minSpeed = 0.00005f;
    public float maxSpeed = 0.0002f;
    public float minRotationSpeed = 0.0002f;
    public float maxRotationSpeed = 0.001f;

    private Vector3 movementDirection;
    private float movementSpeed;
    private Vector3 rotationSpeed;

    void Start()
    {
        // Dirección aleatoria mínima
        movementDirection = Random.onUnitSphere;

        // Velocidad mínima para apenas moverse
        movementSpeed = Random.Range(minSpeed, maxSpeed);

        // Rotación mínima en cada eje
        rotationSpeed = new Vector3(
            Random.Range(minRotationSpeed, maxRotationSpeed) * (Random.value > 0.05f ? 1 : -1),
            Random.Range(minRotationSpeed, maxRotationSpeed) * (Random.value > 0.05f ? 1 : -1),
            Random.Range(minRotationSpeed, maxRotationSpeed) * (Random.value > 0.05f ? 1 : -1)
        );
    }

    void Update()
    {
        // Movimiento y rotación muy leves
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}
