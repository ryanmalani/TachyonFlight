using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    private int count;
    public TMP_Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void UpdateScoreText()
    {
        ScoreText.text = "Score\n" + count;
    }
}
