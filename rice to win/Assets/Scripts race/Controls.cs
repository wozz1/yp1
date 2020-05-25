using System;
using System.IO;
using UnityEngine;


public class Controls : MonoBehaviour
{ 
    public float scores = 0f; //Очки
    public float highScore = 0f; //Высший результат

    void Start()
    {
        string high = File.ReadAllText("highscore");

        try
        {
            highScore = Convert.ToSingle(high);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }

    }
}