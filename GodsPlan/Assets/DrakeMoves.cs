using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeMoves : MonoBehaviour
{
    public GameObject wMove;
    public GameObject aMove;
    public GameObject sMove;
    public GameObject dMove; 

    // Start is called before the first frame update
    void Start()
    {
        wMove.SetActive(false);
        aMove.SetActive(false);
        sMove.SetActive(false);
        dMove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            wMove.SetActive(true);
            aMove.SetActive(false);
            sMove.SetActive(false);
            dMove.SetActive(false);
        }

        if (Input.GetKeyDown("a"))
        {
            wMove.SetActive(false);
            aMove.SetActive(true);
            sMove.SetActive(false);
            dMove.SetActive(false);
        }

        if (Input.GetKeyDown("s"))
        {
            wMove.SetActive(false);
            aMove.SetActive(false);
            sMove.SetActive(true);
            dMove.SetActive(false);
        }

        if (Input.GetKeyDown("d"))
        {
            wMove.SetActive(false);
            aMove.SetActive(false);
            sMove.SetActive(false);
            dMove.SetActive(true);
        }
    }
}
