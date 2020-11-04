using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door;
    public GameObject door2;


    public void open()
    {
        door.SetActive(false);
    }

    public void close()
    {
        door.SetActive(true);
    }

    public void opendoor2()
    {
        door2.SetActive(false);
    }

    public void closedoor2()
    {
        door2.SetActive(true);
    }
}
