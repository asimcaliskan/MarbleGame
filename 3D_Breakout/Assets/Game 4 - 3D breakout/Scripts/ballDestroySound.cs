using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDestroySound : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.StartsWith("BallPrefab"))
        {
            audioSource.Play();
        }
    }
}
