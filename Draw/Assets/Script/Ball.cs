using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            gameObject.SetActive(false);
            manager.ShotControl();
        }
        else if (collision.CompareTag("GameOver"))
        {
            Debug.Log("Lose");
        }
    }
}
