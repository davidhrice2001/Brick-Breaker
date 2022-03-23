using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent fallEvent;
    void OnCollisionEnter2D(Collision2D collision)
    {
        fallEvent.Invoke();
    }
}
