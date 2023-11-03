using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private bool isTouching = false;
    public float zoomInValue = 5f;
    public float zoomOutValue = 10f;
    public float lerpSpeed = 2f; // Ustawienie prędkości interpolacji

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouching = false;
        }
    }

    void Update()
    {
        if (isTouching)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, zoomOutValue, Time.deltaTime * lerpSpeed);
        }
        else
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, zoomInValue, Time.deltaTime * lerpSpeed);
        }
    }
}
