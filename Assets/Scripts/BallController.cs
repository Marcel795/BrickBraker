using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] PaddleController paddle;
    [SerializeField] float speedX = 3f;
    [SerializeField] float speedY = 20f;
    [SerializeField] AudioClip[] ballSounds;
    Vector2 distancePaddleToBall;
    bool IsGameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        //Abstandsvector zwischen Ball und Paddle = Vektor des Balls - Vektor des Paddles
        distancePaddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameStarted)
        {
           LockBallToPaddle();
           ShootBallOnMouseClick();
        }
       
    }

    private void ShootBallOnMouseClick()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX , speedY);
            IsGameStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + distancePaddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGameStarted)
        {
            int randomNumber = UnityEngine.Random.Range(0, ballSounds.Length);
            AudioClip clip = ballSounds[randomNumber];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }

    
    }



}
