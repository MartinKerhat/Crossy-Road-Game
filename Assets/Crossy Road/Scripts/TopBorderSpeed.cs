using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBorderSpeed : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var cf = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
            cf.speed = 1.25f;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            var cf = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
            cf.speed = 0.25f;
        }
    }
}
