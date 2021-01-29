using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float pushX = 2f;
    [SerializeField] float pushY = 15f;
    [SerializeField] AudioClip[] hitSounds;
    [SerializeField] float velocityFactor = 1f;

    // Lock ball to paddle before launch:
    Vector2 paddleBallDistance;
    bool hasLaunched = false;

    // Ball hitting sound:
    AudioSource myAudioSource;

    //
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleBallDistance = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasLaunched)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleBallDistance;
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLaunched = true;
            myRigidBody2D.velocity = new Vector2(pushX, pushY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, velocityFactor), Random.Range(0f, velocityFactor));

        if(hasLaunched)
        {
            AudioClip clip = hitSounds[Random.Range(0, hitSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            // Add velocityTweak to avoid bouncing loop:
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    // Ball is set to inactive when all breakable locks are destroyed. It is called by Level.cs
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }

}
