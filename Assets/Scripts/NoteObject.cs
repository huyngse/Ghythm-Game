using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private bool canBePressed;
    [Header("Attributes")]
    [SerializeField]
    private KeyCode keyToPress;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}
