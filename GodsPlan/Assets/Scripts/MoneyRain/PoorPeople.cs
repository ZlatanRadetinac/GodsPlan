using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorPeople : MonoBehaviour
{
    public int direction = 1;
    public float speed = 0;

    GameObject endPosition;
    GameObject startPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        position.x = position.x + speed * direction;
        this.transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.gameObject.tag == "MoneySample")
        {
            Destroy(other.gameObject);
            GameObject drake = GameObject.FindGameObjectWithTag("Player");
            drake.GetComponent<RichDrake>().score += drake.GetComponent<RichDrake>().dollarsToGive;
        }

        if (other.gameObject.tag == "Wall")
        {
            direction = direction * -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }
}
