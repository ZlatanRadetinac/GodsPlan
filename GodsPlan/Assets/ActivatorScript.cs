using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    public KeyCode key;
    public bool active = false;
    public bool hit = false;
    GameObject note;

    float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note.gameObject);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            timer = 0.5f;
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
