using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCount : MonoBehaviour
{
    public int distanceValue = 1;
    public GameObject distance = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player moved for one point");

            Manager.Instance.UpdateDistanceCount(distanceValue);

            Manager.Instance.UpdateHighScore();

            Destroy(this.gameObject);
        }
    }
}
