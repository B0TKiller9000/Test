using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image[] liveImgs;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI gameOver;

    [SerializeField] private float timer = 60;
    private int liveCount;

    void Start()
    {
        gameOver.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (timer <= 0)
        {
            EndGame("You Won");
        }

        timerText.text = Mathf.RoundToInt(timer).ToString();
        timer -= Time.deltaTime;

        coinText.text = playerController.coins.ToString();
        liveCount = playerController.lives;

        switch (liveCount)
        {
            case 2:
                liveImgs[2].gameObject.SetActive(false); break;
            case 1:
                liveImgs[1].gameObject.SetActive(false); break;
            case 0:
                liveImgs[0].gameObject.SetActive(false); 
                EndGame("You Lost");
                break;
        }
    }

    public void EndGame(string text)
    {
        gameOver.text = text + "\n Your Score : " + playerController.coins;
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0f;
        timer = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
