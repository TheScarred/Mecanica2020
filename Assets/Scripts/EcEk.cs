using UnityEngine;
using UnityEngine.UI;

public class EcEk : MonoBehaviour
{
    Rigidbody rigi;
    GameObject arrow;
    public Image chargeGauge;
    float charge = 0;
    bool charging = false;
    bool moving = false;

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
        arrow = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !moving)
        {
            charging = true;
            arrow.SetActive(moving);
        }

        if (Input.GetKeyUp(KeyCode.Space) && charging)
            Launch();

        if (Input.GetKey(KeyCode.Space) && charging)
            Charge();

        if (!charging && !moving)
            Rotate();

        if (moving && rigi.velocity.magnitude <= 0)
            ReSet();

        Debug.Log(moving);
    }

    public void Charge()
    {
        charge += Time.deltaTime;
        chargeGauge.fillAmount = charge;
    }

    public void Launch()
    {
        moving = true;
        charging = false;
        rigi.AddForce(transform.forward * charge * 1000);
        charge = 0;
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.down * Time.deltaTime * 100);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

    public void ReSet()
    {
        moving = false;
        chargeGauge.fillAmount = charge;
        arrow.SetActive(!moving);
    }
}
