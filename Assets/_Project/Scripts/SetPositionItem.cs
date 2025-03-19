using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionItem : MonoBehaviour
{
    private void SetPosition(Rigidbody2D rb)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DragAndDrop Drag = other.GetComponent<DragAndDrop>();
        if (other.CompareTag("item") && !Input.isDragging )
        {
            Drag.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}
