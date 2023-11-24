using UnityEngine;

public class rectfix : MonoBehaviour
{
    public float targetWidth = 16f;
    public float targetHeight = 9f;
    public float bufferRatio = 0.1f;

    void Start()
    {
        Camera mainCamera = GetComponent<Camera>();

        float currentAspect = (float)Screen.width / Screen.height;
        float targetAspect = targetWidth / targetHeight;

        if (currentAspect < targetAspect)
        {
            float targetOrthographicSize = mainCamera.orthographicSize;
            targetOrthographicSize *= targetAspect / currentAspect;

            float bufferOffset = (1f - (1f + bufferRatio) * (currentAspect / targetAspect)) / 2f;
            //mainCamera.rect = new Rect(bufferOffset, 0f, 1f - 2f * bufferOffset, 1f);

            float bufferScale = 1f / ((1f - bufferRatio) + bufferRatio * (currentAspect / targetAspect));
            targetOrthographicSize *= bufferScale;

            mainCamera.orthographicSize = targetOrthographicSize;
        }
    }
}
