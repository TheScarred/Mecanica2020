using UnityEngine;
using UnityEngine.UI;

public class ThrowWithForce : MonoBehaviour
{
    public GameObject bullet;
    public LineRenderer trail;
    public InputField F, x, ax, ay;
    public Image chargeGauge;

    float g, force = 0, charge = 0;
    bool charging = false;
    public int resolution = 10;

    void Start() => g = Mathf.Abs(Physics.gravity.y);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !charging)
            Begin();

        if (Input.GetKeyUp(KeyCode.Space) && charging)
            Launch();

        if (Input.GetKey(KeyCode.Space) && charging)
            Charge();
    }

    public void Begin() => charging = true;

    public void Launch()
    {
        charging = false;
        Fire(float.Parse(F.text), 35);
        charge = 0;
    }

    public void Charge()
    {
        if (charge < 1)
        {
            charge += Time.deltaTime;
            force = charge * 25;
            F.text = force.ToString();
            chargeGauge.fillAmount = charge;
        }
        else 
        {
            charge = 1;
            force.ToString();
        }
    }

    public void Fire(float force, float angle)
    {
        GameObject go = Instantiate(bullet, trail.gameObject.transform.position, Quaternion.identity);
        Rigidbody rigi = go.GetComponent<Rigidbody>();

        float xAcc = force * Mathf.Cos(angle * Mathf.PI / 180);
        float yAcc = force * Mathf.Sin(angle * Mathf.PI / 180);

        rigi.velocity = new Vector3(0, yAcc, xAcc);

        RenderTrail();
    }

    void RenderTrail()
    {
        trail.positionCount = resolution + 1;
        trail.SetPositions(CalculateTrail());
    }

    Vector3[] CalculateTrail()
    {
        float force = float.Parse(F.text);
        float radAngle = Mathf.Deg2Rad * 35;    
        float xAcc = force * Mathf.Cos(radAngle) / 1;//masa
        float yAcc = force * Mathf.Sin(radAngle) / 1;//masa

        Vector3[] array = new Vector3[resolution + 1];
        float maxDistance =  (Mathf.Pow(force, 2f) * Mathf.Sin(2 * radAngle)) / g;

        ax.text = xAcc.ToString();
        ay.text = yAcc.ToString();
        x.text = maxDistance.ToString();

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            array[i] = CalculatePoint(t, maxDistance, force, radAngle);
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
