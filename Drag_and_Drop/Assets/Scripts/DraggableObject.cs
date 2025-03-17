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
        _rigidbody.gravityScale = 0; // ��������� ���������� �� ����� ��������������
        CameraScroll.IsDraggingObject = true;
    }

    void OnMouseDrag()
    {
        if (!_isDragging) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        newPosition.z = transform.position.z; // ���������� ����
        transform.position = newPosition;
    }

    void OnMouseUp()
    {
        _isDragging = false;
        _rigidbody.gravityScale = 1; // �������� ���������� ����� ����������
        ShelfManager.Instance.CheckPlacement(this);
        CameraScroll.IsDraggingObject = false;
    }
}

