using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    // Define screen width into 16 units:
    [SerializeField] float screenWidthInUnits = 16f;

    Vector2 paddlePosition;
    float mousePositioninUnits;

    void Update()
    {
        paddlePosition = new Vector2(transform.position.x, transform.position.y);
        mousePositioninUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        paddlePosition.x = Mathf.Clamp(mousePositioninUnits, minX, maxX);
        transform.position = paddlePosition;
    }
}
