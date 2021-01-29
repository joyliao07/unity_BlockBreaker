using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int breakableBlocks;

    Ball ball;
    LevelSign levelSign;
    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        ball = FindObjectOfType<Ball>();
    }

    public void CollectBlockCount()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            // Set ball inactive
            ball.SetInactive();

            // Destroy levelSign
            levelSign = FindObjectOfType<LevelSign>();
            levelSign.DestroyLevelSign();

            // Delay 4 seconds before loading the next scene:
            StartCoroutine(CoroutineToLoadNextScene());
        }
    }

    IEnumerator CoroutineToLoadNextScene()
    {
        // Wait for 4 seconds:
        yield return new WaitForSeconds(4);
        sceneLoader.LoadNextScene();
    }
}
