using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("S1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Dead()
    {
        SceneManager.LoadScene("Dead");
    }
}
