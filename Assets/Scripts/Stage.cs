using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Ball ball;
    public RotateWalls rotatewalls;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void checkClear()
    {
        if(ball.isClear[0]==true && ball.isClear[1]==true && ball.isClear[2]==true && ball.isClear[3] == true)
        {
            goNextStage();
            rotatewalls.speed += 0.5f;
        }
    }
    public int sortStage()  //점수에 따라 스테이지를 나눔(100과 10의자리수인 두 자리 정수 ex) score=>32 , currentstage = 3 ||| score=> 193, currentstage = 19)
    {
        int currentstage = ball.score / 10;
        return currentstage;
    }
    public void goNextStage()
    {
        for(int i=0; i<4; i++)
        {
            if (rotatewalls.noExistWall[i] == false)
            {
                ball.Count[i] = Random.Range(2 + (sortStage() / 2 - 1), 4 + (sortStage() / 2));
                ball.tagCount[i] = 0;
                ball.ChangeText(i);
                ball.isClear[i] = false;
            }
        }
    }
}
