using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{

    [SerializeField] TMP_Text moneyText;

    [SerializeField] TMP_Text incomeText;
    [SerializeField] TMP_Text staminaText;
    [SerializeField] TMP_Text speedText;

    [SerializeField] TMP_Text incomeLevelText;
    [SerializeField] TMP_Text staminaLevelText;
    [SerializeField] TMP_Text speedLevelText;

    

    float income = 1.0f;
    float totalMoney;

    float incomePrice = 10;
    float staminaPrice = 10;
    float speedPrice = 10;

    int incomeLevel = 1;
    int staminaLevel = 1;
    int speedLevel = 1;

    void OnEnable()
    {
        EventManager.MousePressEvent += EarnMoney;
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= EarnMoney;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (Data.HaveRecord("IncomeValue"))
            income = Data.GetIncomeValue();

        if (Data.HaveRecord("Money"))
            totalMoney = Data.GetMoney();

        if (Data.HaveRecord("IncomePrice"))
            incomePrice = Data.GetIncomePrice();
        if (Data.HaveRecord("StaminaPrice"))
            staminaPrice = Data.GetStaminaPrice();
        if (Data.HaveRecord("SpeedPrice"))
            speedPrice = Data.GetSpeedPrice();

        if (Data.HaveRecord("IncomeLevel"))
            incomeLevel = Data.GetIncomeLevel();
        if (Data.HaveRecord("StaminaLevel"))
            staminaLevel = Data.GetStaminaLevel();
        if (Data.HaveRecord("SpeedLevel"))
            speedLevel = Data.GetSpeedLevel();


    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = ((int)totalMoney).ToString();


        incomeLevelText.text = "LVL " + incomeLevel;
        staminaLevelText.text = "LVL " + staminaLevel;
        speedLevelText.text = "LVL " + speedLevel;

        incomeText.text = ((int)incomePrice).ToString();
        staminaText.text = ((int)staminaPrice).ToString();
        speedText.text = ((int)speedPrice).ToString();

    }

    void EarnMoney()
    {
        totalMoney += income;
        Data.SaveMoney(totalMoney);
    }

    public void IncomeLevelUp()
    {
        if (totalMoney>=incomePrice)
        {
            incomeLevel++;
            totalMoney -= incomePrice;
            incomePrice *= 1.5f;
            income += 0.05f;
            Data.SaveIncomeLevel(incomeLevel);
            Data.SaveMoney(totalMoney);
            Data.SaveIncomePrice(incomePrice);
            Data.SaveIncomeValue(income);
        }
       

    }
    public void StaminaLevelUp()
    {
        if (totalMoney>=staminaPrice)
        {
            staminaLevel++;
            totalMoney -= staminaPrice;
            staminaPrice *= 1.5f;
            Player.maxStaminaValue += 0.5f;
            Player.startStamina += 1;
            Data.SaveStaminaLevel(staminaLevel);
            Data.SaveMoney(totalMoney);
            Data.SaveStaminaPrice(staminaPrice);
            Data.SaveMaxStamina(Player.maxStaminaValue);
            Data.SaveStartStamina(Player.startStamina);
        }
       
    }
    public void SpeedLevelUp()
    {
        if (totalMoney>=speedPrice)
        {
            speedLevel++;
            totalMoney -= speedPrice;
            speedPrice *= 1.5f;
            PlayerMovement.speed -= 0.002f;
            Data.SaveSpeedLevel(speedLevel);
            Data.SaveMoney(totalMoney);
            Data.SaveSpeedPrice(speedPrice);
            Data.SaveSpeed(PlayerMovement.speed);
        }
 

    }
}
