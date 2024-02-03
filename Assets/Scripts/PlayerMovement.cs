using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Threading;
public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;
    float HInput;
    public float HMul = 2;
    public float JumpForce = 400f;
    public LayerMask groundMask;
    public float jumptime = 0.5f;
    
    public GameManager High_Score;
    private int HighScore;
    public Text highScoreText;
    private void Start()
    {
        HighScore = High_Score.score;
        string path = Application.dataPath + "/HighScore.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, $"{HighScore}");
            highScoreText.text = "High Score : " + HighScore.ToString();
        }
        else if (int.Parse(File.ReadAllText(path)) < HighScore)
        {
            File.WriteAllText(path, $"{HighScore}");
            highScoreText.text = "High Score : " + HighScore.ToString();
        }
        else if (int.Parse(File.ReadAllText(path)) > HighScore)
        {
            highScoreText.text = "High Score : " + File.ReadAllText(path).ToString();
        }
    }
    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        Vector3 FM = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 HM = transform.right * HInput * speed * Time.fixedDeltaTime * HMul;
        rb.MovePosition(rb.position + FM+HM);
    }
    void Update()
    {
        speed += 0.005f;
        HInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            Invoke("OFFJUMP", jumptime);
        }
        if (transform.position.y < -5)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void Die()
    {
        alive = false;
        animator.SetBool("Barkhord", true);
        animator.SetBool("Running", false);
        animator.SetBool("Jump", false);
        Invoke("Restart", 3);
        
        //animator.SetBool("Barkhord", false);
    }
    void Restart()
    {
        Vector3 point = new Vector3(0, 0, 0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, height / 2 + 0.01f, groundMask);
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce);
            animator.SetBool("Jump", true);
            animator.SetBool("Running", false);
        }
    }
    void OFFJUMP()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Running", true);
    }


}
