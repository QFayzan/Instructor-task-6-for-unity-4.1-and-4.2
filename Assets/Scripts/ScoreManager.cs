using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerScoreDisplay;
    public TextMeshProUGUI score0Display;
    public TextMeshProUGUI score1Display;
    public TextMeshProUGUI score2Display;
    public TextMeshProUGUI score3Display;
    private  GameObject[] players;
    public static int playerScore = 0;
    public static int score0 = 0;
    public static int score1 = 0;
    public static int score2 = 0;
    public static int score3 = 0;


    // Start is called before the first frame update
    void Start()
    {
         players = GameObject.FindGameObjectsWithTag("Players");
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreDisplay.text = "Player : " + playerScore.ToString();
        score0Display.text = "Enemy : " + score0.ToString();
        score1Display.text = "Enemy 1 " + score1.ToString();
        score2Display.text = "Enemy 2 : " + score2.ToString();
        score3Display.text = "Enemy 3 : " + score3.ToString();

     }
}
   
