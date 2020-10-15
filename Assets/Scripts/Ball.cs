using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TextScript textscript;
    public Stage stage;
    public RotateWalls rotatewalls;
    public Rigidbody2D rigidbody;   //공의 rigidbody


    public int[] tagCount = new int[4]; //공의 벽 터치 횟수
    public int[] Count = new int[4];
    public bool[] isClear = new bool[4];  //각 벽이 0 이하인지 확인하는 변수

    public int score = 0;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        for (int i = 0; i < 4; i++)
        {
            Count[i] = 1;
            ChangeText(i);
            tagCount[i] = 0;

            isClear[i] = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "redWall":
                if (rotatewalls.noExistWall[0] == false)    // 벽이 존재할 때만 태그판정 + 텍스트 변화 
                {
                    tagCount[0]++;
                    ChangeText(0);
                    ChangeScore(0);
                    rotatewalls.wallCount(0);

                    if (Count[0] - tagCount[0] <= 0)
                    {
                        isClear[0] = true;
                    }
                }
                break;
            case "yellowWall":
                if (rotatewalls.noExistWall[1] == false)
                {
                    tagCount[1]++;
                    ChangeText(1);
                    ChangeScore(1);
                    rotatewalls.wallCount(1);

                    if (Count[1] - tagCount[1] <= 0)
                    {
                        isClear[1] = true;
                    }
                }
                break;
            case "blueWall":
                if (rotatewalls.noExistWall[2] == false)
                {
                    tagCount[2]++;
                    ChangeText(2);
                    ChangeScore(2);
                    rotatewalls.wallCount(2);

                    if (Count[2] - tagCount[2] <= 0)
                    {
                        isClear[2] = true;
                    }
                }
                break;
            case "greenWall":
                if (rotatewalls.noExistWall[3] == false)
                {
                    tagCount[3]++;
                    ChangeText(3);
                    ChangeScore(3);
                    rotatewalls.wallCount(3);

                    if (Count[3] - tagCount[3] <= 0)
                    {
                        isClear[3] = true;
                    }
                }
                break;

        }
        stage.checkClear();
    }

    //중력을 reverse 해주는 함수
    public void ChangeGravity(int gravity)
    {
        rigidbody.velocity = new Vector3(0, 10, 0);
        /*if (gravity == 0.95f) rigidbody.gravityScale = 0;
        else if (gravity == 0) rigidbody.gravityScale = 0.95f;*/
    }

    public void ChangeText(int index)
    {
        switch (index)
        {
            case 0:
                textscript.numberText[0].text = (Count[0] - tagCount[0]).ToString();
                break;
            case 1:
                textscript.numberText[1].text = (Count[1] - tagCount[1]).ToString();
                break;
            case 2:
                textscript.numberText[2].text = (Count[2] - tagCount[2]).ToString();
                break;
            case 3:
                textscript.numberText[3].text = (Count[3] - tagCount[3]).ToString();
                break;
        }
    }

    public void ChangeScore(int index)
    {
        if (Count[index] - tagCount[index] >= 0)
        {
            score++;
            textscript.Score.text = score.ToString();
        }
    }
}
