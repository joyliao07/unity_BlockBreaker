using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSign : MonoBehaviour
{
    [SerializeField] GameObject levelSignSparklesVFX1;
    [SerializeField] AudioClip awesomeSound;

    // levelSign starting position for shaking:
    Vector2 startingPos;

    // levelSign shaking motion:
    float speed = 100.0f; //how fast it shakes
    float amount = 5f; //how much it shakes

    // Sparkle position:
    Vector2 sparklePos1;
    Vector2 sparklePos2;
    Vector2 sparklePos3;

    Level level;

    void Awake()
    {
        startingPos.x = 580;
        startingPos.y = 360;

        // Score position does not translate to levelSign position:
        // score = GameObject.Find("Score Text");
        // newStartingPos = new Vector2(score.transform.position.x, score.transform.position.y);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    void ShakeLevelSign()
    {
        Vector2 shakePos = new Vector2((startingPos.x + Mathf.Sin(Time.time * speed) * amount), startingPos.y);
        transform.position = shakePos;
    }

    void Update()
    {
        // Shake levelSign when all blocks are destroyed:
        if(level.breakableBlocks < 1)
        {
            ShakeLevelSign();
        }
    }

    public void DestroyLevelSign()
    {
        StartCoroutine(CoroutinePart1());
        StartCoroutine(CoroutinePart2());
    }

    IEnumerator CoroutinePart1()
    {
        yield return new WaitForSeconds(1);

        sparklePos1 = new Vector2(3, 8);
        sparklePos2 = new Vector2(7, 9);
        sparklePos3 = new Vector2(12, 8);

        GameObject sparklesForSign1 = Instantiate(levelSignSparklesVFX1, sparklePos1, transform.rotation);
        GameObject sparklesForSign2 = Instantiate(levelSignSparklesVFX1, sparklePos2, transform.rotation);
        GameObject sparklesForSign3 = Instantiate(levelSignSparklesVFX1, sparklePos3, transform.rotation);
        Destroy(sparklesForSign1, 1f);
        Destroy(sparklesForSign2, 1f);
        Destroy(sparklesForSign3, 1f);
    }

    IEnumerator CoroutinePart2()
    {
        yield return new WaitForSeconds(2);

        AudioSource.PlayClipAtPoint(awesomeSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
