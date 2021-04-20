using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour
{
    private gameScript game;

    private void Awake()
    {
        GameObject go = GameObject.Find("Main Camera");
        game = go.GetComponent<gameScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        int point = 0;
        switch(name){
            case "redBlock":
                point = 6;
                break;
            case "orangeBlock":
                point = 5;
                break;
            case "greenBlock":
                point = 4;
                break;
            case "lightGreenBlock":
                point = 3;
                break;
            case "blueBlock":
                point = 2;
                break;
            case "lightBlueBlock":
                point = 1;
                break;
        }
        game.blockHit(point);
        Destroy(gameObject);
    }

}
