using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float maxOffset = 1.5f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var position = rb.position;
        position.x = Mathf.Clamp(target.x, -maxOffset, maxOffset);
        rb.MovePosition(position);
    }
}
