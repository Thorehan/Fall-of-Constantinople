using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {     
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished, loading next scene...");
        SceneManager.LoadScene("TileScene");
    }
}