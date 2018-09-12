using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public float delay;

    private string levelName;
    private int currentIndex;
    //private float time;

    void Start()
    {
        //levelName = Application.loadedLevelName;
        levelName = SceneManager.GetActiveScene().name;

        if (levelName == "Intro")
        {
            currentIndex = 0;
        }
        else if (levelName == "test tutorial")
        {
            currentIndex = 1;
        }
        else if (levelName == "Final Destination")
        {
            currentIndex = 2;
        }

        Invoke("LoadNextScene", delay);
    }

    void LoadNextScene()
    {
        if (currentIndex == 0)
        {
            //Application.LoadLevel(1);
            SceneManager.LoadScene(1);
        }
        else if (currentIndex == 2)
        {
            //Application.LoadLevel(0);
            SceneManager.LoadScene(0);
        }
    }

    //void Update()
    //{
    //    time += Time.fixedDeltaTime;

    //    if (time >= delay)
    //    {
    //        if (currentIndex == 0)
    //        {
    //            Application.LoadLevel(1);
    //        }
    //        else if (currentIndex == 2)
    //        {
    //            Application.LoadLevel(0);
    //        }
    //    }
    //}
}
