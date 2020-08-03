using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int baseScorePerHit = 100;
    int score = 0;
    Text scorePresented;
    // Start is called before the first frame update
    void Start()
    {
        scorePresented = GetComponent<Text>();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreHit()
    {
        score += baseScorePerHit;
        UpdateScore();
    }

    void UpdateScore()
    {
        scorePresented.text = "";
        for( int value = score.ToString().Length; value < 6; value ++)
        {
            scorePresented.text += "0";
        }

        scorePresented.text += score.ToString();
    }
}
