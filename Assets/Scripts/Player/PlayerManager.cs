using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    public bool gameOver;
    public GameObject gameOverPanel;
    public static int numberOfCoins;
    public Text coninsText;

    void Start()
    {
        
        gameOver = false;
        numberOfCoins = 0;
        
    }


    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
        }
        coninsText.text = "Coins: " + numberOfCoins;

    }
}
