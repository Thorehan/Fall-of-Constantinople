using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("TileScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
