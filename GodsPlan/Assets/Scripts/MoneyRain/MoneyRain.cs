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
    public RawImage budgetImage;
    public float faddingSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (budgetImage.color.a > 0)
        {
            Color newColor = budgetImage.color;
            newColor.a = newColor.a - Time.deltaTime * faddingSpeed;
            budgetImage.color = newColor;
        }
    }

    public void EndScene(int score)
    {
        drake.gameObject.SetActive(false);
        woman.gameObject.SetActive(false);
        man.gameObject.SetActive(false);
        oldman.gameObject.SetActive(false);

        endSceneLoveText.text = string.Format("People are no longer poor! Brake people love you!\nYou gave away {0}$\nTHE END", score);

        endScene.SetActive(true);

        if (score > 800000)
        {
            endSceneLoveText.gameObject.SetActive(true);
            endSceneHateText.gameObject.SetActive(false);
        }
        else
        {
            endSceneHateText.gameObject.SetActive(true);
            endSceneLoveText.gameObject.SetActive(false);
        }
    }
}
