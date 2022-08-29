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
            if (!manager.BoxLocked)
            {
                manager.ShotControl(gameObject.transform.position);
            }
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("GameOver"))
        {
            manager.BoxLocked = true;
            manager.Lose(); 
        }
    }
}
