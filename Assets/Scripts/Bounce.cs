using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float g = -9.81f, yI, yF, d, t;

    // los BP no funcionan en mi visual no se porque

    private void Start()
    {
        yI = transform.position.y;
        StartCoroutine(ShootRay());
        t = Mathf.Abs(CalculateTime(d));
        StartCoroutine(Move(transform.position, new Vector3(transform.position.x, transform.position.y - d, transform.position.z), t));
    }

    IEnumerator ShootRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.Log("Ray hit");
            d = Mathf.Abs(hit.distance - transform.localScale.x / 2);
        }
        else
            Debug.Log("No ray hit");

        yield return null;
    }

    IEnumerator Move(Vector3 a, Vector3 b, float t)
    {
        float lerpValue = 0.0f;

        while (lerpValue < t)
        {
            transform.position = Vector3.Lerp(a, b, lerpValue);

            lerpValue += Time.deltaTime;
            yield return null;
        }

        transform.position = b;


        yield return null;
    }

    float CalculateTime(float d)
    {
        return d / g;
    }

    private void OnTriggerEnter(Collider col)
    {
        
    }

/*
    
*/
}
