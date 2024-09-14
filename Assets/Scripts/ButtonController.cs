using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private Sprite pressedImage;
    [SerializeField]
    private KeyCode keyToPress;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            SoundManager.Instance.PlayEffect("hit");
            spriteRenderer.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyToPress)) {
            spriteRenderer.sprite = defaultImage;
        }
    }
}
