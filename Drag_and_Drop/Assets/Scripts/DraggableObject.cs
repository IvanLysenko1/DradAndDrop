using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isDragging;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        _isDragging = true;
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody.gravityScale = 0; // Отключаем гравитацию во время перетаскивания
        CameraScroll.IsDraggingObject = true;
    }

    void OnMouseDrag()
    {
        if (!_isDragging) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        newPosition.z = transform.position.z; // Сохранение слоя
        transform.position = newPosition;
    }

    void OnMouseUp()
    {
        _isDragging = false;
        _rigidbody.gravityScale = 1; // Включаем гравитацию после отпускания
        ShelfManager.Instance.CheckPlacement(this);
        CameraScroll.IsDraggingObject = false;
    }
}

