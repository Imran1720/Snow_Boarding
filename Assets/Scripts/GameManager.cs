
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    GameObject DeadScreen, HUD, WinScreen;

    public DataBase db;

    private void Start()
    {
        Debug.Log(db.IsAndroidDevice);
        if (db.IsAndroidDevice)
        {
            HUD.SetActive(true);
        }
        else
        {
            HUD.SetActive(false);

        }
    }
    public void TurnLeft()
    {

        PlayerController.Instance._leftturn = true;
    }
    public void StopTurnLeft()
    {
        PlayerController.Instance._leftturn = false;
    }
    public void TurnRight()
    {
        PlayerController.Instance._rightturn = true;

    }
    public void StopTurnRight()
    {

        PlayerController.Instance._rightturn = false;
    }

    public void EnableBoost()
    {
        PlayerController.Instance._isBoosting = true;
    }
    public void DisableBoost()
    {
        PlayerController.Instance._isBoosting = false;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    public void Home()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }

    public void Dead()
    {
        Time.timeScale = 0f;
        DeadScreen.SetActive(true);
        if (db.IsAndroidDevice)
            HUD.SetActive(false);
        WinScreen.SetActive(false);

    }
    public void HUDScreen()
    {
        Time.timeScale = 1.0f;
        DeadScreen.SetActive(false);
        if (db.IsAndroidDevice)
            HUD.SetActive(true);
        WinScreen.SetActive(false);

    }
    public void Win()
    {
        Time.timeScale = 0f;
        DeadScreen.SetActive(false);
        if (db.IsAndroidDevice)
            HUD.SetActive(false);
        WinScreen.SetActive(true);

    }

}
