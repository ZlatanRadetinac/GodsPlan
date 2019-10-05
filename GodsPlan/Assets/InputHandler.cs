using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;

    public Color wColor = new Color(243, 171, 53);
    public Color aColor = new Color(33, 236, 51);
    public Color sColor = new Color(253, 247, 69);
    public Color dColor = new Color();
    // Start is called before the first frame update
    void Start()
    {
        var circleRenderer = s.GetComponent<Renderer>();
        circleRenderer.material.SetColor("_Color", Color.yellow);

        circleRenderer = w.GetComponent<Renderer>();
        circleRenderer.material.SetColor("_Color", Color.red);

        circleRenderer = a.GetComponent<Renderer>();
        circleRenderer.material.SetColor("_Color", Color.green);

        circleRenderer = d.GetComponent<Renderer>();
        circleRenderer.material.SetColor("_Color", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            var circleRenderer = s.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", new Color(0, 0, 0));

            var activator = s.GetComponent(typeof(ActivatorScript)) as ActivatorScript;
            var correctnes = GameObject.Find("AnswerCorrectness");
            var tvManager = correctnes.GetComponent(typeof(CorrectnesManager)) as CorrectnesManager;
            if (activator.IsHit())
            {
                tvManager.CorrectAnswer();
            }
            else
            {
                tvManager.WrongAnswer();
            }
        }
        if (Input.GetKeyUp("s"))
        {
            var circleRenderer = s.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", Color.yellow);
        }

        if (Input.GetKeyDown("w"))
        {
            var circleRenderer = w.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", new Color(0, 0, 0));

            var activator = w.GetComponent(typeof(ActivatorScript)) as ActivatorScript;
            var correctnes = GameObject.Find("AnswerCorrectness");
            var tvManager = correctnes.GetComponent(typeof(CorrectnesManager)) as CorrectnesManager;
            if (activator.IsHit())
            {
                tvManager.CorrectAnswer();
            }
            else
            {
                tvManager.WrongAnswer();
            }
        }
        if (Input.GetKeyUp("w"))
        {
            var circleRenderer = w.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", Color.red);
        }

        if (Input.GetKeyDown("a"))
        {
            var circleRenderer = a.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", new Color(0, 0, 0));

            var activator = a.GetComponent(typeof(ActivatorScript)) as ActivatorScript;
            var correctnes = GameObject.Find("AnswerCorrectness");
            var tvManager = correctnes.GetComponent(typeof(CorrectnesManager)) as CorrectnesManager;
            if (activator.IsHit())
            {
                tvManager.CorrectAnswer();
            }
            else
            {
                tvManager.WrongAnswer();
            }
        }
        if (Input.GetKeyUp("a"))
        {
            var circleRenderer = a.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", Color.green);
        }

        if (Input.GetKeyDown("d"))
        {
            var circleRenderer = d.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", new Color(0, 0, 0));

            var activator = d.GetComponent(typeof(ActivatorScript)) as ActivatorScript;
            var correctnes = GameObject.Find("AnswerCorrectness");
            var tvManager = correctnes.GetComponent(typeof(CorrectnesManager)) as CorrectnesManager;
            if (activator.IsHit())
            {
                tvManager.CorrectAnswer();
            }
            else
            {
                tvManager.WrongAnswer();
            }
        }
        if (Input.GetKeyUp("d"))
        {
            var circleRenderer = d.GetComponent<Renderer>();
            circleRenderer.material.SetColor("_Color", Color.blue);
        }
    }
}
