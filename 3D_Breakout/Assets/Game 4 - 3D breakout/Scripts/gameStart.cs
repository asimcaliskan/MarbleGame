using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    public void startGame() 
    {
        SceneManager.LoadScene("Breakout");
    }
}
