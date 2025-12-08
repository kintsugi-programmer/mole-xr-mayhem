using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{
    // Y positions
    public float visibleYHeight = 2.0f;
    public float hiddenYHeight = -1.6f;

    // Movement
    public float speed = 4f;

    // How long the mole stays visible
    public float visibleTime = 1.5f;

    // internal
    private Vector3 targetPosition;
    private float hideMoleTimer;
    private bool isVisible = false;

    void Awake()
    {
        // Start hidden
        HideMole(true);
    }

    void Update()
    {
        // Smoothly move toward target position
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPosition,
            Time.deltaTime * speed
        );

        // Count down only when visible
        if (isVisible)
        {
            hideMoleTimer -= Time.deltaTime;
            if (hideMoleTimer <= 0f)
            {
                HideMole();
            }
        }
    }

    public void ShowMole()
    {
        isVisible = true;
        hideMoleTimer = visibleTime;

        targetPosition = new Vector3(
            transform.localPosition.x,
            visibleYHeight,
            transform.localPosition.z
        );
    }

    public void HideMole(bool instant = false)
    {
        isVisible = false;

        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenYHeight,
            transform.localPosition.z
        );

        // snap instantly at start
        if (instant)
        {
            transform.localPosition = targetPosition;
        }
    }
}
