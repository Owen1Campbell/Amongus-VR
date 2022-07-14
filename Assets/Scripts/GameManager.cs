using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int score;
    public GameObject winMessage;
    public TextMeshProUGUI scoreUI;
    [SerializeField]
    int target = 6;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        winMessage.SetActive(false);
    }

    public void CheckScore()
    {
        if (score > target)
        {
            winMessage.SetActive(true);
        }
    }

    public void ScoreInc()
    {
        score++;

        CheckScore();
    }
}
