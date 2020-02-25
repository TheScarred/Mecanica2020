using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TMPro.TMP_InputField input;
    public TMPro.TextMeshProUGUI output;
    Rigidbody rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    public void ApplyForce()
    {
        float force = float.Parse(input.text);
        rigi.AddForce(Vector3.right * force * 1000);
        output.text = (force * 12).ToString();
    }
}
