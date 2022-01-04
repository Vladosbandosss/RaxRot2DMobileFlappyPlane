using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChoise : MonoBehaviour
{

    [SerializeField] GameObject panelChoise;
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PanelChoiseStatus(bool status)
    {
        panelChoise.SetActive(status);
        int selectedPlane = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(selectedPlane);
        GameMenuManger.instanse.CharIndex = selectedPlane;
    }
}
