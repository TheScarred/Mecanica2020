using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParabolicThrow : MonoBehaviour
{
    public GameObject bullet;
    public Slider velocity, angle;
    public InputField v, a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire(velocity.value, angle.value);
    }

    public void AdjustVelocity() => v.text = velocity.value.ToString();

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

        GameObject go = Instantiate(bullet, transform.position + (transform.up * 2), Quaternion.identity);
        Rigidbody rigi = go.GetComponent<Rigidbody>();

        float xVel = velocity * Mathf.Cos(newAngle * Mathf.PI / 180);
        float yVel = velocity * Mathf.Sin(newAngle * Mathf.PI / 180);

        rigi.velocity = new Vector3(0, yVel, xVel);

        Debug.Log(rigi.velocity);
    }
}
