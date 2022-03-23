using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    static Color[] colors = {
        Color.red,
        new Color(1f, 0.5f, 0f), // Orange
        Color.green
    };
    
    public int health = 2;
    public UnityEvent destroyedEvent;

    void MatchColor()
    {
        var colorIndex = Mathf.Clamp(health, 0, colors.Length - 1);
        GetComponent<SpriteRenderer>().color = colors[colorIndex];
    }
    void Start()
    {
        MatchColor();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            health--;
            MatchColor();
        }
        else
        {
            Destroy(gameObject);
            destroyedEvent.Invoke();
        }
    }
}
