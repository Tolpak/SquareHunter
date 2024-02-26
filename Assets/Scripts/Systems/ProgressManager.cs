using System;
using UnityEngine;
using Zenject;

public class ProgressManager : IInitializable, IDisposable
{
    private const string DistanceKey = "distance";
    private const string ScoreKey = "score";
    private float distance;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }
        set
        {
            distance = value;
        }
    }

    public void Dispose()
    {
        SaveProgress();  
    }

    public void Initialize()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0);
        distance = PlayerPrefs.GetFloat(DistanceKey, 0f);
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetFloat(DistanceKey, distance);
        PlayerPrefs.SetInt(ScoreKey, score);
    }
}
