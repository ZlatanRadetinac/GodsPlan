using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectnesManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hit;
    GameObject miss;

    public Text textComponent;

    public GameObject resultCanvas;
    public int result = 0;
    public int target = 8;

    public GameObject moneyBar;

    void Start()
    {
        hit = this.gameObject.transform.GetChild(1).gameObject;
        miss = this.gameObject.transform.GetChild(2).gameObject;

        hit.SetActive(true);
        miss.SetActive(false);

        resultCanvas = GameObject.Find("ResultCanvas");
        result = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectAnswer()
    {
        miss.SetActive(false);
        hit.SetActive(true);

        result++;

        textComponent.text = "Current: " + result.ToString() + "     Target: " + target.ToString();

        var moneyProgress = moneyBar.GetComponent<ProgressScript>();
        moneyProgress.UpdateMoneyBalance();

        if (result == target)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WorkEndScene");
        }
    }

    public void WrongAnswer()
    {
        hit.SetActive(false);
        miss.SetActive(true);
    }

}
