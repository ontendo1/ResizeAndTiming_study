using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float staticMoveSpeed, rotationSpeed; //Sabit hız ve karakterin dönemeçten döneceği hız.
    [HideInInspector] public float dynamicMoveSpeed; // 0 ve 1 değerini alıp karakterin durmasını ve hareket etmesini sağlar.
    [HideInInspector] public bool isRotating; // Karakter dönemeçten dönüyorsa bu değer true olur.

    void Start()
    {
        dynamicMoveSpeed = 0;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.velocity = transform.forward * staticMoveSpeed * dynamicMoveSpeed;
    }
    public IEnumerator Rotate90()
    {
        isRotating = true;
        dynamicMoveSpeed = 0;

        int i = 0;
        while (i < 90) //Karakterin up axis'inden her karede rotationSpeed değeri kadar döndüren döngüyü başlatır. Toplam 90 derece olmalıdır.
        {
            transform.Rotate(Vector3.up * -rotationSpeed);
            yield return null;
            i += (int)rotationSpeed;
        }
        if (Input.GetMouseButton(0))
        dynamicMoveSpeed = 1;
        
        isRotating = false;
    }
}
