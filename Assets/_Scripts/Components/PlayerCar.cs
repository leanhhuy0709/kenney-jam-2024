using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerCar : Car
{
    void Update()
    {
        UpdateInput();
        Move();
    }

    void UpdateInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CurrentSpeed += Acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CurrentSpeed -= Acceleration * Time.deltaTime;
        }
        else
        {
            CurrentSpeed -= Acceleration * 0.25f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 100f);
        }

        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);
    }
}
