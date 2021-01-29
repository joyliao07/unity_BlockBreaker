using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockExplosion;

    // Update GameSession and Level when blocks are destroyed:
    Level myLevel;
    GameSession myGameSession;
    
    private void Start()
    {
        myLevel = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            myLevel.CollectBlockCount();
        }
        myGameSession = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
            myLevel.BlockDestroyed();
            myGameSession.AddToScore();
        }
    }

}
