using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
   public static bool playGame=false;

    void PlayGame()
    {
        playGame = true;
    }
    void StopGame()
    {
        playGame = false;
    }



}
