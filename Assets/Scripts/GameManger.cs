using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    FonScrolling fon;
    FonScrolling earth;
    
    public static GameManger instance;

    [SerializeField] Text scoreText;

    [SerializeField] Text scoreTextFinal;
    [SerializeField] Text hightScoreText;

    [SerializeField] GameObject panelGameOver;
    int score = 0;

    private string SCORETEXT = "score";
    private string HIGHSCORETEXT = "hightScore";
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        scoreText.text = score.ToString();
        scoreTextFinal.text = score.ToString();
        PlayerPrefs.SetInt(SCORETEXT, score);

        panelGameOver.SetActive(false);

        fon = GameObject.Find("BackGround").GetComponent<FonScrolling>();
        earth = GameObject.Find("Earth").GetComponent<FonScrolling>();
        
    }

   public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }

    public void StopIncreaseScore()
    {
        panelGameOver.SetActive(true);
        PlayerPrefs.SetInt(SCORETEXT, score);
        scoreTextFinal.text = score.ToString();
      
        if (PlayerPrefs.HasKey(HIGHSCORETEXT))
        {
            if (score > PlayerPrefs.GetInt(HIGHSCORETEXT))
            {
                PlayerPrefs.SetInt(HIGHSCORETEXT, score);
                hightScoreText.text = score.ToString();
            }
            else
            {
                hightScoreText.text = PlayerPrefs.GetInt(HIGHSCORETEXT).ToString();
            }

        }
        else
        {
            PlayerPrefs.SetInt(HIGHSCORETEXT, score);
            hightScoreText.text = score.ToString();
        }

        fon.StopScroll();
        earth.StopScroll();
        SoundManger.instanse.StopMusic();

        StartCoroutine(nameof(StopAll));
       
    }

    IEnumerator StopAll()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }

   
    
}
