using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;   // <-- ADD THIS

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text timerText;
    public float gameTimer = 30f;

    [Header("Moles")]
    public Transform moleContainer;
    public float minSpawnDelay = 0.3f;
    public float maxSpawnDelay = 1.0f;

    private Mole[] moles;
    private float spawnTimer;

    public TMP_Text restartText;

    public static GameController Instance;

    public AudioSource sfxSource;

    void Awake()
    {
        Instance = this;
    }

    public void PlayShowMoleSound()
    {
        sfxSource.Play();
    }

    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);

        restartText.gameObject.SetActive(false);  // hide at start
    }

    void Update()
    {
        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer < 0f) gameTimer = 0f;

            timerText.text = "WHACK A MOLE: " + Mathf.FloorToInt(gameTimer);

            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f && moles.Length > 0)
            {
                int index = Random.Range(0, moles.Length);
                moles[index].ShowMole();

                spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
            }
        }
        else
        {
            timerText.text = "GAME OVER";
            restartText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
