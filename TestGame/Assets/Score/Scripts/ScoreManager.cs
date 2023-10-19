using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score;

    [SerializeField] private TMP_Text _textScore;

    private void Awake()
    {
        Instance = this;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        _textScore.text = Score.ToString();
    }
}
