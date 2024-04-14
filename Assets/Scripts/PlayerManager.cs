using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static int numberOfCoins;
    public Text coninsText;

    void Start()
    {
        
        gameOver = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        
    }


    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coninsText.text = "Coins: " + numberOfCoins;

    }
}
