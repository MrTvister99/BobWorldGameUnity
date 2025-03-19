using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector3 originalScale;
    private Canvas canvas;
    private Vector3 offset;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private float minY, maxY;
    [SerializeField] private float shrinkScale = 0.8f; 
    [SerializeField] private float duration = 0.2f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalScale = rectTransform.localScale;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Input.isDragging = true;
        rigidbody2D.simulated = false;
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        offset = rectTransform.position - mouseWorldPosition;
        rectTransform.DOScale(originalScale * shrinkScale, duration);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Input.isDragging = false;
        rigidbody2D.simulated = true;
        rectTransform.DOScale(originalScale, duration);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Vector3 newPosition = mouseWorldPosition + offset;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        rectTransform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = UnityEngine.Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
