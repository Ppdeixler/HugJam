using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text houses;

    [SerializeField]
    private TMP_Text firefighters;

    [SerializeField]
    private TMP_Text hospitals;


    //MENU PAUSE
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;
    public string menuScene = "MainMenu";

    private void Update()
    {
        houses.text = Resources.houses.ToString();
        firefighters.text = Resources.firefightbuild.ToString();
        hospitals.text = Resources.hospital.ToString();

        //MENU PAUSE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }

    //MENU PAUSE
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(menuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
