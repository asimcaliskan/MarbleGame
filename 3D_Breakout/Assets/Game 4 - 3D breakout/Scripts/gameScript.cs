using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    public Transform ballPrefab;
    public Transform fastBuff;
    public Transform slowBuff;
    public Transform doubleBuff;
    public Transform halfBuff;
    public Text scoreText;
    public Text liveBallsText;
    private int score;
    private int liveBalls = 0;
    public int numberOfHitBlocks = 0;
    private AudioSource audioSource;
    public GameObject youWinImage;//Give reference to YouWin game object.

    public void spawnBallPrefab()
    {
        Instantiate(ballPrefab, new Vector3(0f, 0f, 20f), Quaternion.identity);
        liveBalls++;
    }

    private void spawnBuffBall()
    {
        int randomInt = Random.Range(0, 4);
        int initialPos_x = Random.Range(-19, 20);
        switch (randomInt)
        {
            case 0:
                Instantiate(fastBuff, new Vector3(initialPos_x, 0f, 20f), Quaternion.identity);
                break;
            case 1:
                Instantiate(slowBuff, new Vector3(initialPos_x, 0f, 20f), Quaternion.identity);
                break;
            case 2:
                Instantiate(halfBuff, new Vector3(initialPos_x, 0f, 20f), Quaternion.identity);
                break;
            case 3:
                Instantiate(doubleBuff, new Vector3(initialPos_x, 0f, 20f), Quaternion.identity);
                break;
        }
    }

    void Awake()
    {
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
            SceneManager.LoadScene("RestartScene");
        }
        if(numberOfHitBlocks == 78)//numberOfRows(13) * numberOfColumns(6) = total(78)
        {
            SceneManager.LoadScene("FinishScene");
            audioSource.Play();
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
        if (numberOfHitBlocks % 8 == 0)
        {
            spawnBuffBall();
        }
        score += point;
    }

    public void bottomWallHit()
    {
        liveBalls--;
    }
}
