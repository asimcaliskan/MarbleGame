using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffBallScrip : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("bottomWall"))
        {
            Destroy(gameObject);
        }
    }
}
