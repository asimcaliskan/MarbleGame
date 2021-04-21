using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMusicScript : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void playGameMusic()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }
}
