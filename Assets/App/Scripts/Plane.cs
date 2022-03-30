using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if(transform.position.y < -2.5f)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scoring"))
        {
            AddScore();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void AddScore()
    {
        Debug.Log("add score");
    }

    private void GameOver()
    {
        Debug.Log("Game over");
        Time.timeScale = 0f;
        gameoverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
