using UnityEngine;
using UnityEngine.UI;

public class EcEk : MonoBehaviour
{
    Rigidbody rigi;
    public Image chargeGauge;
    float charge = 0;
    bool charging = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            charging = true;

        if (Input.GetKey(KeyCode.Space) && charging)
            Charge();

        if (Input.GetKeyUp(KeyCode.Space))
            Launch();

    }

    public void Charge()
    {
        charge += Time.deltaTime;
        chargeGauge.fillAmount = charge;
        transform.localScale = Vector3.one + (Vector3.one * charge);
    }

    public void Launch()
    {
        charging = false;
        rigi.AddForce(Vector3.right * charge * 1000);
    }

    public void ResetBall()
    {
        charge = 0;
        chargeGauge.fillAmount = charge;
        transform.localScale = Vector3.one;
    }
}
