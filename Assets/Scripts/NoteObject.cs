using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private KeyCode keyToPress;
    private float baseY = 0;
    private bool canBePressed;
    private bool obtained = false;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                if (Mathf.Abs(transform.position.y - baseY) < 0.2f)
                {
                    GameManager.Instance.NoteHit(300);
                }
                else
                if (Mathf.Abs(transform.position.y - baseY) < 0.4f)
                {
                    GameManager.Instance.NoteHit(100);
                }
                else
                {
                    GameManager.Instance.NoteHit(50);
                }
                obtained = true;
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
            if (!obtained)
            {
                GameManager.Instance.NoteMiss();
            }
            canBePressed = false;
        }
    }
}
