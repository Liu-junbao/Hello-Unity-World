using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    Material _material;
    Vector2 _movement;
    public Vector2 Speed;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        _movement += Speed * Time.deltaTime;
        _material.mainTextureOffset = _movement;
    }
}
