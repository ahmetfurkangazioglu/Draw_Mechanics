using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BallShot ballShot;
    [SerializeField] DrawLine draw;
    public void ShotControl()
    {
        ballShot.ShotControl();
        draw.ShotControl();
    }
}
