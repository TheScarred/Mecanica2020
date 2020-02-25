using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public Girl otherGirl;
    public TMPro.TMP_InputField mass;
    public TMPro.TMP_InputField move;
    Rigidbody rigi;
    
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    public void SetUpdate()
    {
        if (otherGirl.mass.text == "" || otherGirl.move.text == "")
        {

            rigi.mass = float.Parse(mass.text);

            if (otherGirl.mass.text == "")
                otherGirl.mass.text = (rigi.mass * float.Parse(move.text) / float.Parse(otherGirl.move.text)).ToString();
            else
                otherGirl.move.text = (rigi.mass * float.Parse(move.text) / float.Parse(otherGirl.mass.text)).ToString();
        }

    }
}
