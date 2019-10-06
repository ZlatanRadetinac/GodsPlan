using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gm.CanUserPlay)
        {
            return;
        }
    }
}
