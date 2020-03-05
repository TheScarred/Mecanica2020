using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDespawn : MonoBehaviour
{
    private void OnCollisionEnter(Collider other) => gameObject.SetActive(false);

}
