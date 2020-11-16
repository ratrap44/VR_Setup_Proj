using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key1")
        {
            door.SetActive(false);
        }
    }

}
