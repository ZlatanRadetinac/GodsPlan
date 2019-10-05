using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RichDrake : MonoBehaviour
{
    GameObject happyDrakeWithMoney;
    GameObject happyRegularDrake;
    public GameObject moneySample;
    GameObject currentMoneyObject;
    GameObject handPosition;

    public float speed = 0.05F;
    public int dollars = 100000000;
    public int score = 100000000;

    public Text scoreText;
    public Text moneyLeftText;

    // Start is called before the first frame update
    void Start()
    {
        happyDrakeWithMoney = GameObject.FindGameObjectWithTag("RickDrakeWithMoneyInHand");
        happyRegularDrake = GameObject.FindGameObjectWithTag("RichDrake");
        handPosition = GameObject.FindGameObjectWithTag("HandPosition");
        happyDrakeWithMoney.SetActive(false);
        happyRegularDrake.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x - speed;
            this.transform.position = position;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x + speed;
            this.transform.position = position;
        }

        if (Input.GetKeyDown("space"))
        {
            happyRegularDrake.SetActive(false);
            happyDrakeWithMoney.SetActive(true);

            currentMoneyObject = GameObject.Instantiate(moneySample, transform, false);
            currentMoneyObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
            currentMoneyObject.GetComponentInChildren<Rigidbody2D>().simulated = false;
            dollars -= 1000;
        }

        if (Input.GetKey("space"))
        {
            Vector3 moneyPosition = handPosition.transform.position;
            moneyPosition.z = moneyPosition.z + 10;
            currentMoneyObject.transform.position = moneyPosition;
        }

        if (Input.GetKeyUp("space"))
        {
            currentMoneyObject.GetComponentInChildren<BoxCollider2D>().enabled = true;
            currentMoneyObject.GetComponentInChildren<Rigidbody2D>().simulated = true;

            happyRegularDrake.SetActive(true);
            happyDrakeWithMoney.SetActive(false);
        }

        scoreText.text = string.Format("Score: {0}", score);
        moneyLeftText.text = string.Format("Money left: {0}$", dollars);
    }

    void UpdateScore(int score)
    {
        this.score += score;
    }
}
