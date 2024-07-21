using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public float MaxSpeed;
    public float Acceleration;

    public float CurrentSpeed;
    public Vector3 CurrentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrentVelocity();
    }

    void UpdateCurrentVelocity()
    {
        var angle = transform.rotation.eulerAngles.z * Mathf.PI / 180f;
        var x = -Mathf.Sin(angle);
        var y = Mathf.Cos(angle);

        CurrentVelocity = new Vector3(x, y, 0f) * CurrentSpeed;
    }

    // Update is called once per frame

    void Update()
    {
        Move();
    }

    public void Move()
    {
        UpdateCurrentVelocity();
        this.transform.position += CurrentVelocity * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        var otherCar = collision.gameObject.GetComponent<Car>();
        if (otherCar != null)
        {
            // var velocity = otherCar.CurrentVelocity + CurrentVelocity * 0.5f;

            // otherCar.CurrentSpeed = Vector3.Distance(velocity, Vector3.zero);
        }
        else
        {
            CurrentSpeed -= MaxSpeed * 0.1f;
            CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);
        }
    }
}
