using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshPro timerText;
    public float gameTimer = 30f; // 30 seconds for game Timer

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // Update the Game Timer
    gameTimer -= Time.deltaTime; // subtracts 1 second from game timer
    // Check Game Timer is greater than 0 seconds
    if (gameTimer > 0f)
    {
        // Update Text in Unity
        timerText.text = "WHACK A MOLE: " + Mathf.Floor(gameTimer);
    }
    // Game Timer less than @ seconds
    else
    {
        // Update Text in Unity to Game Over
        timerText.text = "GAME OVER";
    }
        
    }
}

