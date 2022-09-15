using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Texture oneKill, twoKill, threeKill;
    Renderer myRenderer;
    private Rigidbody rb;
    public float speed = 5.0f;
    private bool isDead = false;
    public static bool scaleUp = false;
    public GameObject lastCollisionWith;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frames
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.forward * speed * forwardInput *2);
        rb.AddForce(Vector3.right * speed * sideInput *2);

        if (transform.position.y <-1 && isDead)
        {
            isDead = true;
            GameEnd();
        }
    }
    void LateUpdate()
    {
        ScaleIncrease();
    }
    public void  OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Players"))
        {
        lastCollisionWith = other.gameObject;
       // Debug.Log("lastCollisionWith " + lastCollisionWith);
        }
    }
    void GameEnd()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
     void ScaleIncrease()
    {
        if(ScoreManager.playerScore >0)
        {
            if(scaleUp)
            {
            transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f);
            myRenderer.material.SetTexture("_MainTex",oneKill );
            scaleUp =false;
            }
        }
        else if (ScoreManager.playerScore >1)
        {
            if(scaleUp)
            {
            transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f);
            myRenderer.material.SetTexture("_MainTex",twoKill );
            scaleUp =false;
            }
        }
        else if (ScoreManager.playerScore>2)
        {
            if(scaleUp)
            {
            transform.localScale = transform.localScale + new Vector3 (0.2f ,0.2f ,0.2f);
            myRenderer.material.SetTexture("_MainTex",threeKill );
            scaleUp =false;
            }
        }
    }
}
