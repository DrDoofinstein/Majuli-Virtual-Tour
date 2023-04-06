using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {/*
        SceneManager.LoadScene("SampleScene");*/

        videoPlayer.loopPointReached += OnVideoCompleted;
    }

    void OnVideoCompleted(VideoPlayer vp)
    {
        SceneManager.LoadScene("HomeScene");
    }
}
