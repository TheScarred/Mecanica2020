using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParabolicThrow : MonoBehaviour
{
    public GameObject bullet;
    public LineRenderer trail;
    public Slider velocity, angle;
    public InputField v, a, x, h;

    float g;
    public int resolution = 10;

    // Start is called before the first frame update
    void Start()
    {
        g = Mathf.Abs(Physics.gravity.y);
        RenderTrail();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire(velocity.value, angle.value);
    }

    public void AdjustVelocity() 
    {
        v.text = velocity.value.ToString();
        RenderTrail();
    } 

    public void AdjustRotation()
    {
        float offset = angle.value - 45;

        if (offset > 0)
            a.text = (45 - offset).ToString();
        else if (offset < 0)
            a.text = (45 - offset).ToString();
        else
            a.text = angle.value.ToString();

        transform.eulerAngles = new Vector3(angle.value, 0, 0);
        RenderTrail();
    }

    public void Fire(float velocity, float angle)
    {
        float newAngle;
        float offset = angle - 45;

        if (offset > 0)
            newAngle = 45 - offset;
        else if (offset < 0)
            newAngle = 45 - offset;
        else
            newAngle = angle;

        GameObject go = Instantiate(bullet, trail.gameObject.transform.position, Quaternion.identity);
        Rigidbody rigi = go.GetComponent<Rigidbody>();

        float xVel = velocity * Mathf.Cos(newAngle * Mathf.PI / 180);
        float yVel = velocity * Mathf.Sin(newAngle * Mathf.PI / 180);

        rigi.velocity = new Vector3(0, yVel, xVel);

        Debug.Log(rigi.velocity);
    }

    void RenderTrail()
    {
        trail.positionCount = resolution + 1;
        trail.SetPositions(CalculateTrail());
    }

    Vector3[] CalculateTrail()
    {
        float vel = float.Parse(v.text);
        float radAngle = Mathf.Deg2Rad * float.Parse(a.text);
        Vector3[] array = new Vector3[resolution + 1];
        float maxDistance = (Mathf.Pow(vel, 2f) * Mathf.Sin(2 * radAngle)) / g;
        float maxHeight = (Mathf.Pow(vel, 2f) * Mathf.Pow(Mathf.Sin(radAngle), 2)) / (2 * g);
        x.text = maxDistance.ToString();
        h.text = maxHeight.ToString();

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            array[i] = CalculatePoint(t, maxDistance, vel, radAngle);
        }

        return array;
    }

    Vector3 CalculatePoint(float t, float max, float velocity, float angle)
    {
        float x = t * max;
        float y = x * Mathf.Tan(angle) - ((g * Mathf.Pow(x, 2)) / (2 * Mathf.Pow(velocity, 2) * Mathf.Cos(angle) * Mathf.Cos(angle)));
        return new Vector3(x, y);
    }
}
