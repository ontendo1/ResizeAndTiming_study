using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed, magnitude, offset;
    float timeStep;
    Vector3 startPosition;

    void Start()
    {
        timeStep = Time.time * speed + offset;
        startPosition = transform.position;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        timeStep = Time.time * speed + offset;
        transform.position = startPosition + direction * Mathf.Sin(timeStep) * magnitude;
    }
}

