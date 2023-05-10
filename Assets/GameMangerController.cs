using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangerController : MonoBehaviour
{
    
    public GameObject gameOverUI;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
}
