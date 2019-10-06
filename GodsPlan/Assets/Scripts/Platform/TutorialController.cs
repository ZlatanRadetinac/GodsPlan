using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameManager gm;

    private bool move = false;
    private bool showMenu = false;
    private bool waitForAck = false;
    private bool startGame = false;

    public PlayerController drake;
    public Vector3 drakeEndPos;
    public Vector3 drakeStartPos;
    public float remainingTime = 3;

    public Canvas tutorialCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        gm.CanUserPlay = false;

        tutorialCanvas.enabled = false;

        drake = FindObjectOfType<PlayerController>();
        drakeEndPos = drake.transform.position;
        drakeStartPos = new Vector3(drakeEndPos.x - 3, drakeEndPos.y, drakeEndPos.z);
        drake.transform.position = drakeStartPos;

        move = true;
    }

    public void TextAck()
    {
        tutorialCanvas.enabled = false;
        waitForAck = false;
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (remainingTime > 0)
            {
                print("Lerping");
                remainingTime -= Time.deltaTime;
                print(remainingTime);
                drake.transform.position = Vector3.Lerp(drakeStartPos, drakeEndPos, (3f - remainingTime) / 3f);
                return;
            }

            drake.transform.position = drakeEndPos;
            move = false;
            showMenu = true;
        }

        if (showMenu)
        {
            showMenu = false;
            tutorialCanvas.enabled = true;
            waitForAck = true;
        }

        if (waitForAck)
        {
            return;
        }

        if (startGame)
        {
            gm.CanUserPlay = true;
        }
    }
}
