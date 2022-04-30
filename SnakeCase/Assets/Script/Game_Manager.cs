using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject level;
    //public TMPro.TextMeshProUGUI highScore;

    void Start()
    {
        /*
        if (highScore != null)
        {
            highScore.text = PlayerPrefs.GetInt("CurrentHighScore").ToString();

        }*/
    }


    bool levels;
    public void level_btn()
    {
        levels = !levels;
        if (levels)
        {
            level.SetActive(true);
        }
        else
        {
            level.SetActive(false);
        }


    }



    public void level_load(int level)
    {
        SceneManager.LoadScene(level);
    }







}
