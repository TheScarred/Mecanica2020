using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntoDeEncuentro : MonoBehaviour
{
    public InputField v1, v2, p;
    public movement p1, p2;

    public void Calculate()
    {
        float vel1 = float.Parse(v1.text);
        float vel2 = float.Parse(v2.text);
        float t = 500 / (vel1 + vel2);
        float x1 = -250 + (vel1 * t);
        float x2 = -250 + (vel2 * t);

        p.text = x1.ToString();

        p1.Move(t, x1, vel1, true);
        p2.Move(t, x2, vel2, false);

        Debug.Log("x1f: " + x1  + "  " + "x2f: " + x2  + "  t: " + t);
    }
}
