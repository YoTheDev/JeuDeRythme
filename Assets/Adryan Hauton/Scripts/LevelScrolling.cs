using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrolling : MonoBehaviour
{
    private Transform _lineTransform;
    public float _scrollingSpeed;
    bool isCharged;
    void Start()
    {
        isCharged = false;
        Invoke("Scroller", 2f);
        _lineTransform = GetComponent<Transform>();
    }
    
    void FixedUpdate()
    {
        if (isCharged)
        {
            _lineTransform.Translate(_scrollingSpeed, 0, 0); 
        }
    }

    void Scroller()
    {
        isCharged = true;
    }
}
