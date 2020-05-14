using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinballPaddle : MonoBehaviour
{
    public InputField k, x, eP, F;
    public GameObject paddle, ball;
    public float ForceMultiplier = 1;


    private float kV, xV, ePV, FV = 0;

    private Rigidbody ballRigi;
    private Vector3 scale;

    void Start()
    {
        scale = paddle.transform.localScale;
        ballRigi = ball.GetComponent<Rigidbody>();

        UpdateK();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && paddle.transform.localScale.y > 0.1)
        {
            FV += Time.deltaTime;
            F.text = FV.ToString();
            paddle.transform.localScale = new Vector3(paddle.transform.localScale.x, paddle.transform.localScale.y - Time.deltaTime, paddle.transform.localScale.z);
            xV = scale.y - paddle.transform.localScale.y;
            x.text = xV.ToString();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Launch();
        }
    }

    public void Launch()
    {
        F.text = FV.ToString(); x.text = xV.ToString();
        float deltaX = scale.y - paddle.transform.localScale.y;
        paddle.transform.localScale = scale;
        float energiaP = kV * Mathf.Pow(deltaX, 2);
        ballRigi.AddForce(energiaP * Vector3.up * ForceMultiplier);
        eP.text = energiaP.ToString();
        FV = xV = 0;
    }

    public void UpdateK()
    {
        kV = float.Parse(k.text);
    }

}
