using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody ball;

    private void OnCollisionEnter(Collision collision)
    {
        ball.velocity = Vector3.right * 80;
    }
}
