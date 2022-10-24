using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Text scoreText;
    private int totalScore;
    public int scoreMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void FixedUpdate()
    {
        totalScore += scoreMultiplier;
        scoreText.text = totalScore.ToString();
    }
}
