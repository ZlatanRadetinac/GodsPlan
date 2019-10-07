using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressScript : MonoBehaviour
{
    Slider slider;
    Text textComponent;
    float moneyBalance = 0; 

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
        slider.value = 0;
        textComponent = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoneyBalance()
    {
        slider.value += 12.5F;
        moneyBalance += 996631.90f / 8;
        textComponent.text = "Balance: " + moneyBalance.ToString() + " $";
    }
}
