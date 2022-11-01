using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject RestartScreen;

    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firsttouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
