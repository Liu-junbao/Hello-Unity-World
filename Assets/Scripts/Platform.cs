using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 _movement;
    GameObject _topLine;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        _movement.y = Speed;
        _topLine = GameObject.Find("TopLine");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        this.transform.position += _movement * Time.deltaTime;
        if (this.transform.position.y >= _topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
