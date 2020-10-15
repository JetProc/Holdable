using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public RotateWalls rotatewalls;
    public Ball ball;

    public Vector3 ballPos;
    public Vector3 diePos;
    public Canvas endGameScreen;
    public ParticleSystem dieParticle;

    public bool isAlive;
    void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        ballPos = Camera.main.WorldToViewportPoint(ball.transform.position);
        checkDie();
    }

    public void checkDie()
    {
        if (isAlive == true)
        {
            if (ballPos.x > 1 || ballPos.x < 0 || ballPos.y > 1 || ballPos.y < 0)
            {
                isAlive = false;
                rotatewalls.speed = 0f;
                ball.gameObject.SetActive(false);   //공을 없앰
                diePos = ball.gameObject.transform.position;    //diepos는 파티클 위치 선정을 위함
                DyingParticle();
                Invoke("restart", 3);
            }
        }
    }
    public void DyingParticle()
    {
        dieParticle.gameObject.transform.position = diePos;
        dieParticle.Play();
    }
    public void restart()
    {
        endGameScreen.gameObject.SetActive(true);   
    }
}
