using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManger : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    public static GameMenuManger instanse;
    private int _charIndex;
   
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnlevelFinishiedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnlevelFinishiedLoading;
    }

    void OnlevelFinishiedLoading(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Game")
        {
            Instantiate(players[_charIndex]);
        }
    }
}
