using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public GameObject coin = null;
    public AudioClip audioClip = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up a coin!");
        }

        Manager.Instance.UpdateCointCount(coinValue);

        Manager.Instance.UpdateHighScore();

        coin.SetActive(false);

        this.GetComponent<AudioSource>().PlayOneShot(audioClip);

        Destroy(this.gameObject, audioClip.length);
    }
}
