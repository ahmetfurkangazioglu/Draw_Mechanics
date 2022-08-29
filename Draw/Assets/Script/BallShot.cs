using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject ShotPoint;
    [SerializeField] GameObject Box;
    [SerializeField] GameObject[] BoxPoint;
    [SerializeField] GameManager manager;
    int CurrentBall;
    int ShotAmount;
    bool Locked;

    IEnumerator ShotOperation()
    {
        while (true)
        {
            if (!Locked)
            {
                DrawLine.Locked = false;
                yield return new WaitForSeconds(1f);
                manager.GeneralSounds[2].Play();
                BallOperation();
                Invoke("BoxOperation", 0.7f);
                Invoke("StartTime", 5f);
                Locked = true;
            }
            else
            {
                yield return null;
            }
        }   
    }
    public void ShotControl()
    {
        Box.SetActive(false);
        CancelInvoke();
        Locked = false;
    }
    public void StartGame()
    {
        StartCoroutine(ShotOperation());
    }
    void BallOperation()
    {
        if (ShotAmount != 0 && ShotAmount % 3==0)
        {
            manager.OperationOrder = 2;
            for (int i = 0; i < 2; i++)
            {
                BallAndShotOperation();
            }
        }
        else
        {
            BallAndShotOperation();
        }
        ShotAmount++;
    }
    void BoxOperation()
    {
        int randrom = Random.Range(0, BoxPoint.Length);
        Box.transform.position = BoxPoint[randrom].transform.position;
        Box.SetActive(true);
    }
    void StartTime()
    {
        manager.Lose();
        manager.BoxLocked = true;
    }
    void BallAndShotOperation()
    {
        Balls[CurrentBall].transform.position = ShotPoint.transform.position;
        Balls[CurrentBall].SetActive(true);
        Balls[CurrentBall].GetComponent<Rigidbody2D>().AddForce(750 * NewPos());
        if (CurrentBall != Balls.Length - 1)
        {
            CurrentBall++;
        }
        else
        {
            CurrentBall = 0;
        }
    }
    Vector3 NewPos()
    {
        return Quaternion.AngleAxis(RandomAngle(70f,110f), Vector3.forward) * Vector3.right;
    }
    float RandomAngle(float value1, float value2)
    {
        return Random.Range(value1, value2);
    }

}
