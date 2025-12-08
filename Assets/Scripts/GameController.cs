using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text timerText;          // Drag your TextMeshPro object here
    public float gameTimer = 30f;       // 30 seconds for game Timer

    [Header("Moles")]
    public Transform moleContainer;     // Drag MoleContainer here
    public float minSpawnDelay = 0.3f;  // Min time between moles popping
    public float maxSpawnDelay = 1.0f;  // Max time between moles popping

    private Mole[] moles;               // All Mole scripts under MoleContainer
    private float spawnTimer;           // Counts down to next mole pop

    void Start()
    {
        // Get all Mole components from children of moleContainer
        moles = moleContainer.GetComponentsInChildren<Mole>();

        // First random delay
        spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void Update()
    {
        // -------- TIMER UI --------
        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer < 0f) gameTimer = 0f;

            timerText.text = "WHACK A MOLE: " + Mathf.FloorToInt(gameTimer);

            // -------- MOLE POPPING --------
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f && moles.Length > 0)
            {
                // Pick random mole and show it
                int index = Random.Range(0, moles.Length);
                moles[index].ShowMole();

                // Set time until next mole
                spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
            }
        }
        else
        {
            timerText.text = "GAME OVER";
        }
    }
}
