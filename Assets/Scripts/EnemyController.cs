using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Texture oneKill, twoKill, threeKill;
    Renderer myRenderer;
    public TextMeshProUGUI scoreText;
    private bool isDead = false;
    public GameObject lastCollisionWith = null;
    public float speed = 5.0f;
    private Rigidbody enemyRb;
    private  GameObject[] players;
    public static bool enemyScaleUp = false;

    void Start()
    {
        var randSize = Random.Range(0.4f,1.0f);
        myRenderer = GetComponent<Renderer>();
        enemyRb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Players");
       transform.localScale = transform.localScale + new Vector3 (randSize,randSize,randSize) ;
        enemyRb.mass = randSize;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in players)
        {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        }
        if (transform.position.y <-0.5 && !isDead)
        {
        Die();
        } 
    }
    void LateUpdate()
    {
        ScaleIncrease();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Players") && !isDead)
        {
        lastCollisionWith = other.gameObject;
        }
    }
    void Die()
    {
        string lastCollide = lastCollisionWith.name ;
        if (lastCollide == "Enemy" )
        {
            ScoreManager.score0++;
            enemyScaleUp = true;
        }
        else if(lastCollide == "Enemy (1)")
        {
            ScoreManager.score1++;
            enemyScaleUp = true;
           
        }
        else if(lastCollide == "Enemy (2)")
        {
            ScoreManager.score2++;
            enemyScaleUp = true;
        }
        else if(lastCollide == "Enemy (3)")
        {
            ScoreManager.score3++;
            enemyScaleUp = true;
        }
        else if(lastCollide == "Player")
        {
            ScoreManager.playerScore++;
            PlayerController.scaleUp = true;
        }
        lastCollisionWith.transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f) ;
        isDead = true;
        gameObject.SetActive(false);
    }
     void ScaleIncrease()
    {
        if(ScoreManager.score0 >0 || ScoreManager.score1 >0 || ScoreManager.score2 >0 || ScoreManager.score3 >0)
        {
            if(enemyScaleUp)
            {
            transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f);
            myRenderer.material.SetTexture("_MainTex",oneKill );
            enemyScaleUp =false;
            }
        }
        else if(ScoreManager.score0 >1 || ScoreManager.score1 >1 || ScoreManager.score2 >1 || ScoreManager.score3 >1)
        {
            if(enemyScaleUp)
            {
            transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f);
            myRenderer.material.SetTexture("_MainTex",twoKill );
            enemyScaleUp =false;
            }
        }
        else if(ScoreManager.score0 >2 || ScoreManager.score1 >2 || ScoreManager.score2 >2 || ScoreManager.score3 >2)
        {
            if(enemyScaleUp)
            {
            transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f);
            myRenderer.material.SetTexture("_MainTex",threeKill );
            enemyScaleUp =false;
            }
        }
    }
}
