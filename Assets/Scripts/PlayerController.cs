using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 6f;
    private float movement = 0f;
    private float movementUpDown = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public Animator playerAnimation;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    public int live = 2;
    public Text playerText;
    public Text playerTextEndGame;
    public Text textEndGame;
    public PauseManu pauseMenu;
    private float scaleX = 0.3f;
    private float scaleY = 0.3f;
    private int countTimeDie = 0;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        playerText.text = "     : " + live;
        playerTextEndGame.text = "     : " + live;
        textEndGame.text = "Game Over";
        pauseMenu = FindObjectOfType<PauseManu>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        movementUpDown = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0.5f * speed);
        transform.localScale = new Vector2(scaleX, scaleY);

        if (countTimeDie != 0)
        {
            countTimeDie++;
        }
        if (countTimeDie == 200)
        {
            playerAnimation.SetBool("IsInvisible", false);
            countTimeDie = 0;
        }

        //đi phải
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        //đi trái
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-scaleX, scaleY);
        }

        //đi tiến
        if (movementUpDown > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        //đi lùi
        else if (movementUpDown < 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -jumpSpeed);
        }

        // set animator
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        if (live <= 0)
        {
            pauseMenu.OpenScreen();
            // EndGameScreen.SetActive(true);
            // Time.timeScale = 0f;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            //chết
            countTimeDie++;
            playerAnimation.SetBool("IsInvisible", true);
            live--;
            playerText.text = "     : " + live;
            playerTextEndGame.text = "     : " + live;
            // what happen when player enter the FallDetector zone
            respawnPoint.x = transform.position.x;
            respawnPoint.y = transform.position.y + 4;
            transform.position = respawnPoint;
        }
        if (other.tag == "Boom")
        {
            countTimeDie++;
            playerAnimation.SetBool("IsInvisible", true);
            live--;
            playerText.text = "     : " + live;
            playerTextEndGame.text = "     : " + live;
        }
        if (other.tag == "AddLive")
        {
            live++;
            playerText.text = "     : " + live;
            playerTextEndGame.text = "     : " + live;
        }
        if (other.tag == "MilkTea")
        {
            if (scaleY <= 1f)
            {
                scaleX += 0.12f;
                scaleY += 0.12f;
            }
        }
        if (other.tag == "EatCoin1")
        {
            SetScale(-0.04f);
        }
        if (other.tag == "EatCoin3")
        {
            SetScale(-0.08f);
        }
        if (other.tag == "EatCoin5")
        {
            SetScale(-0.12f);
        }
    }

    public void SetPlayerText()
    {
        playerText.text = "     : " + live;
        playerTextEndGame.text = "     : " + live;
    }

    private void SetScale(float scale)
    {

        if (scaleY >= (0.3f - scale))
        {
            scaleX += scale;
            scaleY += scale;
        }

    }

}
