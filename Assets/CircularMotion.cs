using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularMotion : MonoBehaviour
{
    public Slider radius, velocity;
    public InputField r, s, T, f, w, ac;

    private void FixedUpdate()
    {
        if (velocity.value > 0)
            Motion();
    }

    public void UpdateRadiusField()
    {
        r.text = radius.value.ToString();
        transform.localScale = new Vector3(radius.value, transform.localScale.y, transform.localScale.z);
        UpdateVariables();
    }

    public void UpdateSpeedField()
    {
        s.text = velocity.value.ToString();
        UpdateVariables();
    }

    public void Motion()
    {
        transform.Rotate(0, velocity.value * Time.deltaTime, 0);
    }

    public void UpdateVariables()
    {
        double twoPi, vel, r, period, frequency, angularVel, centripetalAcc;

        twoPi = 2 * Mathf.PI;
        vel = velocity.value;
        r = radius.value;
        period = (twoPi * r) / vel;
        frequency = 1 / period;
        angularVel = twoPi * frequency;
        centripetalAcc = Mathf.Pow((float)vel, 2) / r;


        T.text = period.ToString();
        f.text = frequency.ToString();
        w.text =  angularVel.ToString();
        ac.text = centripetalAcc.ToString();
    }

}