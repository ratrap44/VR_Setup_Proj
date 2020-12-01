using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key3")
        {
            door.SetActive(true);
        }
    }
}
