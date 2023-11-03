using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform target;
    private Transform defaultTarget;
    private bool isInCollider = false;

    private void Start()
    {
        if (virtualCamera)
        {
            defaultTarget = virtualCamera.Follow;
        }
    }

    private void Update()
    {
        if (isInCollider)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (virtualCamera)
                {
                    virtualCamera.Follow = target;
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (virtualCamera)
                {
                    virtualCamera.Follow = defaultTarget;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInCollider = false;
            if (virtualCamera)
            {
                virtualCamera.Follow = defaultTarget;
            }
        }
    }
}
