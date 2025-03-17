using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public static bool IsDraggingObject = false; // Флаг блокировки

    [SerializeField] private float _scrollSpeed = 5f; // Скорость прокрутки
    [SerializeField] private float _minX; // Левая граница
    [SerializeField] private float _maxX; // Правая граница
                                          
    private Vector3 _dragOrigin;

    void Update()
    {
        if (IsDraggingObject) return; // Блокируем движение камеры во время перетаскивания

        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 difference = _dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = transform.position + new Vector3(difference.x, 0, 0);

            newPosition.x = Mathf.Clamp(newPosition.x, _minX, _maxX);
            transform.position = newPosition;
        }
    }
}
