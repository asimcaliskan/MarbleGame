using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class gameStart : MonoBehaviour
{
    public GameObject gameStartImage;//Give reference to GameStartImage game object.
    public void StartGame() 
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        gameStartImage.SetActive(false);
    }
}
