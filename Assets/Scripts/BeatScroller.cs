using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private float beatTempo = 128;
    [SerializeField]
    private bool hasStarted = false;
    [SerializeField]
    private float scrollSpeed = 1;
    void Start()
    {
        beatTempo /= 60f;
    }

    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime * scrollSpeed, 0f);
        }
    }
}
