using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject levelSign;
    [SerializeField] TextMeshProUGUI score;

    Vector2 levelSignPos;

    public void CreateLevelSign()
    {
        // Create new levelSign
        levelSignPos = new Vector2(score.transform.position.x + 180, score.transform.position.y - 80);
        GameObject newSign = Instantiate(levelSign, levelSignPos, transform.rotation);

        // Get specific level number:
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("currentSceneIndex is: " + currentSceneIndex);

        // Update levelSign number:
        TextMeshProUGUI mText = newSign.GetComponent<TextMeshProUGUI>();
        mText.text = "Level " + currentSceneIndex;

        // Update newSign parent:
        newSign.transform.parent = gameObject.transform;
    }
}
