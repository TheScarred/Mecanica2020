using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 start, end;
    float startTime, l, t, x, vel;
    bool go = false;
    bool moveRight;

    public void Move(float _t, float _x, float _vel, bool mR) 
    {
        moveRight = mR;
        start = transform.position;
        if (mR)
            end = new Vector3(_x, -50, 250);
        else
            end = new Vector3(-_x, -50, 250);
        startTime = Time.time;
        t = _t;
        x = _x;
        vel = _vel;
        l = Vector3.Distance(transform.position, end);
        go = true;

        Debug.Log(gameObject.name + " " + end);
    }
    void Update()
    {
        if (go) 
        {
            float distCovered = (Time.time - startTime) * vel;
            float fraccion = distCovered / l;
            transform.position = Vector3.Lerp(start, end, fraccion);
        }
    }
}
