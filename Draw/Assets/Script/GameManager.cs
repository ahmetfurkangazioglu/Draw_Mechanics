using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] BallShot ballShot;
    [SerializeField] DrawLine draw;
    [SerializeField] GameObject[] GeneralPanel;
    [SerializeField] TextMeshProUGUI[] GeneralText;
    int Score;

    private void Start()
    {
        Score = 0;
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        GeneralText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void ShotControl()
    {
        Score++;
        GeneralText[2].text = Score.ToString();
        ballShot.ShotControl();
        draw.ShotControl();
    }

    public void StartGame()
    {
        GeneralPanel[0].SetActive(false);
        GeneralPanel[1].SetActive(true);
        ballShot.StartGame();
    }
    public void Lose()
    {
        DrawLine.Locked = true;
        GeneralText[1].gameObject.SetActive(true);
        GeneralText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
        GeneralText[1].text =Score.ToString();
        if (Score>PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", Score);
        }
        GeneralPanel[0].SetActive(true);
        GeneralPanel[1].SetActive(false);
        GeneralPanel[2].SetActive(true);
        GeneralPanel[3].SetActive(false);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
