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

    public bool isBack = false;

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

        if (isBack)
        {
            x = -x;
            y = -y;
        }

        // if (CurrentVelocity.x * x < 0f) x = -x;
        // if (CurrentVelocity.y * y < 0f) y = -y;

        CurrentVelocity = new Vector3(x, y, 0f) * CurrentSpeed;
    }

    // Update is called once per frame

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (isColliding && (Time.time - collisionStartTime) > 0.5f)
        {
            CurrentSpeed = 0;
            collisionStartTime = Time.time;
        }
        UpdateCurrentVelocity();
        this.transform.position += CurrentVelocity * Time.fixedDeltaTime;
    }

    private bool isColliding = false;
    private float collisionStartTime;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isColliding)
        {
            isColliding = true;
            collisionStartTime = Time.time;
        }
        var otherCar = collision.gameObject.GetComponent<Car>();
        if (otherCar != null)
        {
            // var velocity = otherCar.CurrentVelocity + CurrentVelocity * 0.5f;

            // otherCar.CurrentSpeed = Vector3.Distance(velocity, Vector3.zero);
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            CurrentVelocity = Vector3.Reflect(CurrentVelocity, normal);

            CurrentSpeed -= Acceleration * 0.5f * Time.fixedDeltaTime;
            CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);

            // Debug.Log(normal);

            // if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
            // {
            //     CurrentSpeed *= 0.5f;
            //     isBack = !isBack; // Bound
            // }

            if (collision.contactCount > 4) CurrentSpeed = 0f;

            UpdateCurrentVelocity();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }

    public bool IsColliding()
    {
        return isColliding;
    }
}
