using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenManager : Singleton<HomeScreenManager>
{
    [SerializeField]
    GameObject _Main, _levels, Backbtn, Desc;

    public bool _isAndroid = true;
    public DataBase db;

    private void Start()
    {
        if (!_isAndroid)
        {
            Desc.SetActive(true);
        }
        else
        {
            Desc.SetActive(false);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowLevels()
    {
        _Main.SetActive(false);
        _levels.SetActive(true);
        Backbtn.SetActive(true);
    }
    public void HideLevels()
    {
        _Main.SetActive(true);
        _levels.SetActive(false);
        Backbtn.SetActive(false);
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void LoadLvl3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void EnableAndroidCntrl()
    {
        _isAndroid = !_isAndroid;
        db.IsAndroidDevice = _isAndroid;

        if (!_isAndroid)
        {
            Desc.SetActive(true);
        }
        else
        {
            Desc.SetActive(false);
        }
    }
}
