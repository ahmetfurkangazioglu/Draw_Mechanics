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
    [SerializeField] ParticleSystem[] Effects;
    [HideInInspector] public AudioSource[] GeneralSounds;
    public int OperationOrder;
    public bool BoxLocked;
    int Score;
    bool LoseControl;
    

    private void Start()
    {
        OperationOrder = 1;
        Score = 0;
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        GeneralText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void ShotControl(Vector2 pos)
    {
        Score++;
        Effects[0].transform.position = pos;
        Effects[0].gameObject.SetActive(true);
        GeneralSounds[0].Play();
        GeneralText[2].text = Score.ToString();
        if (OperationOrder==2)
        {
            OperationOrder--;
        }
        else
        {
            ballShot.ShotControl();
            draw.ShotControl();
        }     
    }

    public void StartGame()
    {
        GeneralPanel[0].SetActive(false);
        GeneralPanel[1].SetActive(true);
        ballShot.StartGame();
    }
    public void Lose()
    {
        if (!LoseControl)
        {
            LoseControl = true;
            DrawLine.Locked = true;
            GeneralSounds[1].Play();
            GeneralText[1].gameObject.SetActive(true);
            GeneralText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
            GeneralText[1].text = Score.ToString();
            if (Score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", Score);
                Effects[1].gameObject.SetActive(true);
            }
            GeneralPanel[0].SetActive(true);
            GeneralPanel[1].SetActive(false);
            GeneralPanel[2].SetActive(true);
            GeneralPanel[3].SetActive(false);
        }  
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
