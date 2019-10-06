using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out var x))
        {
            FindObjectOfType<GameManager>().LevelCompleted();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
