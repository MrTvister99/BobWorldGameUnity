using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public Camera mainCamera;
    public float scrollSpeed = 5f;
    public float minX = -10f;
    public float maxX = 10f;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (!Input.isDragging)
        { 
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = UnityEngine.Input.mousePosition;
        }

        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = UnityEngine.Input.mousePosition - lastMousePosition;
            Vector3 newCameraPosition = mainCamera.transform.position + new Vector3(-delta.x, 0, 0) * scrollSpeed * Time.deltaTime;

            newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);

            mainCamera.transform.position = newCameraPosition;
            lastMousePosition = UnityEngine.Input.mousePosition;
        }
    }
}
}

