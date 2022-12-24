using UnityEngine;

public class EnemyRoller : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotationSpeed);
    }
}
