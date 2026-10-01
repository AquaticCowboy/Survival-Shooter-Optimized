using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public UnityEvent<string> UpdateScore;


    void Awake ()
    {
        score = 0;
    }


    void Update ()
    {
        UpdateScore.Invoke("Score: " + score);
    }
}
