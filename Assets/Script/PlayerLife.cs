using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public DataSO data;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private Text timeText;
    [SerializeField] private Text helthText;
    public float time;
    float timeCounter = 0f;
    private int playerHealth;
    void Start()
    {
        time = data.time;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeText.text = "" + time;
        playerHealth = data.playerHealth;
        helthText.text = "Health :" + playerHealth;

    }
    private void Update()
    {
        helthText.text = "Health :" + playerHealth;
        if (time > 0)
        {
            TimeCounter();
        }
        else
        {
            anim.SetTrigger("death");
            anim.SetBool("isDeath", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster") || col.gameObject.CompareTag("Boss")) && playerHealth <= 1)
        {
            helthText.text = "Health :0";
            Die();
        }
        else if (col.gameObject.CompareTag("DeadZone"))
        {
            Die();
        }
        else if((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster") || col.gameObject.CompareTag("Boss")) && playerHealth > 1)
        {
            Hit();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster")) && playerHealth <= 1)
        {
            helthText.text = "Health :0";
            Die();
        }
        else if ((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster")) && playerHealth > 1)
        {
            Vector3 hit = new Vector2(0f, 200f);
            rb.AddForce(hit);
            anim.SetTrigger("hit");
            Hit();
        }
    }

    public void Hit()
    {
        Vector3 hit = new Vector2(0f, 200f);
        rb.AddForce(hit);
        anim.SetTrigger("hit");
        playerHealth -= 1;
        Debug.Log("2");
    }
    public void Die()
    {
        anim.SetTrigger("death");
        anim.SetBool("isDeath", true);
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void GoToUpgrade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void TimeCounter()
    {
        timeCounter += Time.deltaTime;
        {
            if (timeCounter >= 1f)
            {
                time -= 1;
                timeText.text = "" + time;
                timeCounter = 0f;
            }
        }
    }
}
