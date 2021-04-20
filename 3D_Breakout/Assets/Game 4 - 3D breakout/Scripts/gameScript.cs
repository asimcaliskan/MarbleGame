using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    public Transform ballPrefab;
    public Text scoreText;
    public Text liveBallsText;
    private int score;
    private int liveBalls = 0;
    public int numberOfHitBlocks = 0;
    private AudioSource audioSource;


    public void spawnBallPrefab()
    {
        Instantiate(ballPrefab, new Vector3(0f, 0f, 20f), Quaternion.identity);
        liveBalls++;
    }

    void Awake()
    {
        Time.timeScale = 0f;
        spawnBallPrefab();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        scoreText.text = "SCORE " + score;
        liveBallsText.text = "LIVE BALLS " + liveBalls;
        if(liveBalls == 0)
        {
            SceneManager.LoadScene("Breakout");
        }
        
    }

    public void blockHit(int point)
    {
        audioSource.Play();
        numberOfHitBlocks++;
        if(numberOfHitBlocks % 10 == 0)
        {
            spawnBallPrefab();
        }
        score += point;
    }

    public void bottomWallHit()
    {
        liveBalls--;
    }
}
