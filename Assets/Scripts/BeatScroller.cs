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
    private float scrollSpeed = 1;
    private bool hasStarted = false;

    public bool HasStarted { get => hasStarted; set => hasStarted = value; }

    void Start()
    {
        beatTempo /= 60f;
    }

    void Update()
    {
        if (!HasStarted)
        {
            // if (Input.anyKeyDown)
            // {
            //     HasStarted = true;
            // }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime * scrollSpeed, 0f);
        }
    }
}
