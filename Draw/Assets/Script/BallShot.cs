using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject ShotPoint;
    [SerializeField] GameObject Box;
    [SerializeField] GameObject[] BoxPoint;
    int CurrentBall;
    bool Locked;

    private void Start()
    {
        StartCoroutine(ShotOperation());
    }
    IEnumerator ShotOperation()
    {
        while (true)
        {
            if (!Locked)
            {
                yield return new WaitForSeconds(1f);
                BallOperation();
                Invoke("BoxOperation", 0.7f);
                Locked = true;
            }
            else
            {
                yield return null;
            }
        }   
    }


    void BallOperation()
    {
        Balls[CurrentBall].transform.position = ShotPoint.transform.position;
        Balls[CurrentBall].SetActive(true);
        float angel = Random.Range(70f, 110f);
        Vector3 Pos = Quaternion.AngleAxis(angel, Vector3.forward) * Vector3.right;
        Balls[CurrentBall].GetComponent<Rigidbody2D>().AddForce(750 * Pos);
        if (CurrentBall != Balls.Length - 1)
        {
            CurrentBall++;
        }
        else
        {
            CurrentBall = 0;
        }
    }
    void BoxOperation()
    {
        int randrom = Random.Range(0, BoxPoint.Length);
        Box.transform.position = BoxPoint[randrom].transform.position;
        Box.SetActive(true);
    }

    public void ShotControl()
    {
        Box.SetActive(false);
        Locked = false;
    }
}
