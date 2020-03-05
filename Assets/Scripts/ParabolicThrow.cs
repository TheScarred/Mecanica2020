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
        a.text = angle.value.ToString();
        transform.eulerAngles = new Vector3(angle.value, 0, 0);
    }

    public void Fire(float velocity, float angle)
    {
        Debug.Log(velocity);

        GameObject go = Instantiate(bullet, transform.position + new Vector3(0,1.5f, 1.5f), Quaternion.identity);
        Rigidbody rigi = go.GetComponent<Rigidbody>();

        float xVel = velocity * Mathf.Cos(angle * Mathf.PI / 180);
        float yVel = velocity * Mathf.Sin(angle * Mathf.PI / 180);

        rigi.velocity = new Vector3(0, yVel, xVel);

        Debug.Log(rigi.velocity);
    }
}
