using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{

    public void ReplayGame()
    {
        SceneManager.LoadScene("TileScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
