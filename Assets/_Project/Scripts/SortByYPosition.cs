using System.Collections.Generic;
using UnityEngine;

public class SortByYPosition : MonoBehaviour
{
    void Update()
    {

        var children = new List<Transform>();
        foreach (Transform child in transform)
        {
            children.Add(child);
        }
        children.Sort((a, b) => b.position.y.CompareTo(a.position.y));
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetAsLastSibling();
        }
    }
}
