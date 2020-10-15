using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWalls : MonoBehaviour
{
    public Ball ball;
    public TextScript textscript;

    public GameObject[] wall = new GameObject[4];

    public bool[] noExistWall = new bool[4];
    public float turnSpeed = 0f;    //회전 속도
    public float speed;

    private void Start()
    {
        speed = 100f;
        for (int i = 0; i < 4; i++)
        {
            noExistWall[i] = false;
        }
    }
    void Update()
    {
        rotateAlways();
        this.transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime); //벽 회전
    }

    //오른쪽 버튼 눌렀을 때 실행되는 함수
    public void pressRightBtn()
    {
        turnSpeed = -speed;
        ball.ChangeGravity(0);
    }

    //왼쪽 버튼 눌렀을 때 실행되는 함수
    public void pressLeftBtn()
    {
        turnSpeed = speed;
        ball.ChangeGravity(0);
    }

    //실시간으로 speed의 값에 따라 회전 속도를 바꿈
    public void rotateAlways()
    {
        if (turnSpeed > 0)
        {
            turnSpeed = speed;
        }
        else if (turnSpeed < 0)
        {
            turnSpeed = -speed;
        }
    }

    public void wallCount(int n)
    {
        if (ball.Count[n] - ball.tagCount[n] <= -3)
        {
            wall[n].gameObject.SetActive(false);
            noExistWall[n] = true;
            textscript.numberText[n].text = "-";
        }
    }
}
