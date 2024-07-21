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
            var angle = transform.rotation.eulerAngles.z * Mathf.PI / 180f;
            var x = -Mathf.Sin(angle);
            var y = Mathf.Cos(angle);
            CurrentVelocity += new Vector3(x, y, 0f) * Acceleration * Time.deltaTime;
            CurrentSpeed = Vector3.Distance(CurrentVelocity, Vector3.zero);
            if (Math.Abs(CurrentSpeed) < 0.001f) isBack = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            var angle = transform.rotation.eulerAngles.z * Mathf.PI / 180f;
            var x = -Mathf.Sin(angle);
            var y = Mathf.Cos(angle);
            CurrentVelocity -= new Vector3(x, y, 0f) * Acceleration * Time.deltaTime;
            CurrentSpeed = Vector3.Distance(CurrentVelocity, Vector3.zero);
            if (Math.Abs(CurrentSpeed) < 0.001f) isBack = true;
        }
        else
        {
            CurrentSpeed -= Acceleration * 0.25f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
            CurrentSpeed -= Acceleration * 0.05f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 100f);
            CurrentSpeed -= Acceleration * 0.05f * Time.deltaTime;
        }

        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);
    }
}
