using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("GameLevel", level);
    }
    public static int GetLevel()
    {
        return PlayerPrefs.GetInt("GameLevel");
    }
    public static void SaveScore(float score)
    {
        PlayerPrefs.SetFloat("Score", score);
    }
    public static float GetScore()
    {
        return PlayerPrefs.GetFloat("Score");
    }
    public static void SaveMoney(float money)
    {
        PlayerPrefs.SetFloat("Money", money);
    }
    public static float GetMoney()
    {
        return PlayerPrefs.GetFloat("Money");
    }

    public static void SaveSpeed(float speed)
    {
        PlayerPrefs.SetFloat("SpeedValue", speed);
    }
    public static float GetSpeed()
    {
        return PlayerPrefs.GetFloat("SpeedValue");
    }

    public static void SaveStartStamina(float stamina)
    {
        PlayerPrefs.SetFloat("StartStamina", stamina);
    }
    public static float GetStartStamina()
    {
        return PlayerPrefs.GetFloat("StartStamina");
    }
    public static void SaveMaxStamina(float stamina)
    {
        PlayerPrefs.SetFloat("MaxStamina", stamina);
    }
    public static float GetMaxStamina()
    {
        return PlayerPrefs.GetFloat("MaxStamina");
    }

    public static void SaveIncomeValue(float income)
    {
        PlayerPrefs.SetFloat("IncomeValue", income);
    }
    public static float GetIncomeValue()
    {
        return PlayerPrefs.GetFloat("IncomeValue");
    }


    public static void SaveIncomePrice(float income)
    {
        PlayerPrefs.SetFloat("IncomePrice", income);
    }
    public static float GetIncomePrice()
    {
        return PlayerPrefs.GetFloat("IncomePrice");
    }
    public static void SaveStaminaPrice(float stamina)
    {
        PlayerPrefs.SetFloat("StaminaPrice", stamina);
    }
    public static float GetStaminaPrice()
    {
        return PlayerPrefs.GetFloat("StaminaPrice");
    }
    public static void SaveSpeedPrice(float speed)
    {
        PlayerPrefs.SetFloat("SpeedPrice", speed);
    }
    public static float GetSpeedPrice()
    {
        return PlayerPrefs.GetFloat("SpeedPrice");
    }

    public static void SaveIncomeLevel(int level)
    {
        PlayerPrefs.SetInt("IncomeLevel", level);
    }
    public static int GetIncomeLevel()
    {
        return PlayerPrefs.GetInt("IncomeLevel");
    }
    public static void SaveStaminaLevel(int level)
    {
        PlayerPrefs.SetInt("StaminaLevel", level);
    }
    public static int GetStaminaLevel()
    {
        return PlayerPrefs.GetInt("StaminaLevel");
    }
    public static void SaveSpeedLevel(int level)
    {
        PlayerPrefs.SetInt("SpeedLevel", level);
    }
    public static int GetSpeedLevel()
    {
        return PlayerPrefs.GetInt("SpeedLevel");
    }

    public static bool HaveRecord(string recordName)
    {
        if (PlayerPrefs.HasKey(recordName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
