using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrolling : MonoBehaviour
{
    private Transform _lineTransform;
    public float _scrollingSpeed;
    void Start()
    {
        _lineTransform = GetComponent<Transform>();
    }
    
    void Update()
    {
        _lineTransform.Translate(_scrollingSpeed, 0, 0);
    }
}
