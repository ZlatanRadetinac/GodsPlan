using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    public Vector2[] vectorArray = new Vector2[]
    {
        new Vector2(6.96f,5),
        new Vector2(8.97f,5),
        new Vector2(10.96f,5),
        new Vector2(12.89f,5)
    };

    public float Timer = 0.5f;
    public GameObject note; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= 1 * Time.deltaTime;

        if(Timer <= 0)
        {
            SendNewNote();
            Timer = 1;
        }
    }

    void SendNewNote()
    {
        Instantiate(note);

        //sending note to the random line
        int lineId = Random.Range(0, 4);
        Vector2 notePosition = vectorArray[lineId];
        note.transform.position = notePosition;

        // Adding physics to the note
        note.AddComponent<Rigidbody2D>();
        note.AddComponent<CircleCollider2D>();

        var rigidBody = note.GetComponent<Rigidbody2D>();
        rigidBody.mass = 1;
        rigidBody.velocity = new Vector2(0, -0.2f);

        // tagging note with Note tag so activator can detect collision
        note.tag = "Note";
    }


}
