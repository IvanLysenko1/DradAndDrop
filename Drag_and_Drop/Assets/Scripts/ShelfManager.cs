using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public static ShelfManager Instance;
    public List<Transform> Shelfs;

    void Awake()
    {
        Instance = this;
    }

    public void CheckPlacement(DraggableObject obj)
    {
        Transform bestShelf = null;
        float bestDistance = float.MaxValue;

        foreach (var shelf in Shelfs)
        {
            float distance = Vector2.Distance(obj.transform.position, shelf.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestShelf = shelf;
            }
        }

        if (bestShelf != null && bestDistance < 1f) // Условие привязки к полке
        {
            obj.transform.position = new Vector3(bestShelf.position.x, bestShelf.position.y, bestShelf.position.z - 0.1f);
            obj.GetComponent<Rigidbody2D>().gravityScale = 0; // Фиксируем объект
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
