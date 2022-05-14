using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int levelCount = 50;
    public Text coin = null;
    public Text distance = null;
    public Text highScoreCoins = null;
    public Text highScoreDistance = null;
    public new Camera camera = null;
    public GameObject guiGameOver = null;
    public GameObject guiHighScore = null;
    public LevelGenerator levelGenerator = null;

    private int currentCoins = 0;
    private int currentDistance = 0;
    private int highCoins;
    private int highDistance;

    private bool canPlay = false;

    private static Manager s_Instance;
    public static Manager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(Manager)) as Manager;
            }

            return s_Instance;
        }
    }

    private void Start()
    {
        for (int i = 0; i<levelCount; i++)
        {
            levelGenerator.RandomGenerator();
        }

        GameControl.control.Load();

        highScoreCoins.text = GameControl.control.highCoins.ToString();

        highScoreDistance.text = GameControl.control.highDistance.ToString();
    }

    public void UpdateCointCount(int value)
    {
        Debug.Log("Player picked up another coin" + value);

        currentCoins += value;

        coin.text = currentCoins.ToString();
    }

    public void UpdateDistanceCount (int value)
    {
        Debug.Log("player moved for one point");

        currentDistance += value;

        distance.text = currentDistance.ToString();

        levelGenerator.RandomGenerator();
    }

    public void UpdateHighScore()
    {
        if ((currentCoins + currentDistance) > (GameControl.control.highCoins + GameControl.control.highDistance))
        {
            GameControl.control.highCoins = currentCoins;

            highScoreCoins.text = GameControl.control.highCoins.ToString();

            GameControl.control.highDistance = currentDistance;

            highScoreDistance.text = GameControl.control.highDistance.ToString();

            GameControl.control.Save();
        }
    }


    public bool CanPlay ()
    {
        return canPlay;
    }

    public void StartPlay ()
    {
        canPlay = true;
    }

    public void GameOver ()
    {
        camera.GetComponent<CameraShake>().Shake();
        camera.GetComponent<CameraFollow>().enabled = false;

        GuiGameOver();
    }

    void GuiGameOver ()
    {
        Debug.Log("Game Over!");

        guiGameOver.SetActive(true);

        guiHighScore.SetActive(true);
    }

    public void PlayAgain ()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
