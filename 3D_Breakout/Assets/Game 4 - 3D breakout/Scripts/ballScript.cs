using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public gameScript game;
    void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -20);
        GameObject go = GameObject.Find("Main Camera");
        game = go.GetComponent<gameScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody hitObject = collision.rigidbody;
        if (hitObject != null)
        {
            string hitObjectName = hitObject.name;
            if (hitObjectName == "bottomWall")
            {
                game.bottomWallHit();
                Destroy(gameObject);
            }
        }
    }
}
