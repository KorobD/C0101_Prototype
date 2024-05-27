using UnityEngine;

public static class SaveLoadScore 
{
    public static void SaveScore(int currentScore)
    {
        PlayerPrefs.SetInt("RecordScore", currentScore);
    }

    public static int LoadScore()
    {
        return PlayerPrefs.GetInt("RecordScore");
    }
}
