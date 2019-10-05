using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    public KeyCode key;
    public bool active = false;
    public bool hit = false;
    GameObject note;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        active = true; 
        if (collider.gameObject.tag == "Note")
        {
            note = collider.gameObject;
            hit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        active = false;
        hit = false;
    }

    public bool IsHit()
    {
        return hit;
    }
}
