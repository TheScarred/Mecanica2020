using UnityEngine;
using UnityEngine.UI;

public class Inertia : MonoBehaviour
{
    public InputField team1, team2;
    private float p1, p2;

    void Start()
    {
        p1 = float.Parse(team1.text);
        p2 = float.Parse(team2.text);
    }

    // Update is called once per frame
    void Update()
    {
        if ((p1 != 0 || p2 != 0) && (p1 != p2))
            Pull();
    }

    public void Pull()
    {
        float direction = p2 - p1;
        transform.Translate(Vector3.right * direction * Time.deltaTime);
    }

    public void AddLeft()
    {
        p1++;
        team1.text = p1.ToString();
    }

    public void AddRight() 
    {
        p2++;
        team2.text = p2.ToString();
    }
}
