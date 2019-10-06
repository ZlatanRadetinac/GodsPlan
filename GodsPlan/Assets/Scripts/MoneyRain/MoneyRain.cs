using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyRain : MonoBehaviour
{
    public RichDrake drake;
    public PoorPeople woman;
    public PoorPeople oldman;
    public PoorPeople man;
    public GameObject endScene;
    public Text endSceneLoveText;
    public Text endSceneHateText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EndScene(int score)
    {
        drake.gameObject.SetActive(false);
        woman.gameObject.SetActive(false);
        man.gameObject.SetActive(false);
        oldman.gameObject.SetActive(false);
        endSceneLoveText.text = string.Format("People are no longer poor! Drake people love you!\nYou gave away {0}$\nTHE END", score);

        endScene.SetActive(true);
    }
}
