using UnityEngine;

public class Shelf : MonoBehaviour
{
    private void Start()
    {
        ShelfManager.Instance.Shelfs.Add(gameObject.transform);
    }
}
