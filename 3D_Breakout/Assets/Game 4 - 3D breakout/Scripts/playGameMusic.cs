using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playGameMusic : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameMusic").GetComponent<gameMusicScript>().playGameMusic();
    }
}
