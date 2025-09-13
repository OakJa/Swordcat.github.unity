using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStus : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health;
    public bool canTakeDamage = true;
    public Slider HPbarSlider;   // Slider UI element for health bar
    public Text HPText;          // Text UI element for displaying health
    public GameOverscreen GameOverscreen;   // Game Over UI

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        health = maxHealth;
        animator = GetComponentInParent<Animator>();

        if (HPbarSlider != null)
        {
            HPbarSlider.maxValue = maxHealth;
            HPbarSlider.value = health;
        }
    }

    void Update()
    {
        if (HPText != null)
        {
            HPText.text = "HP: " + health.ToString() + " / " + maxHealth.ToString();
        }

        if (HPbarSlider != null)
        {
            HPbarSlider.value = health;
        }
    }
  
    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
            return;

        health -= damage;

        animator.SetTrigger("Hurt");  

        if (health <= 0f && !isDead)
        {
            isDead = true;
            animator.SetBool("dead", true);
            GetComponent<PolygonCollider2D>().enabled = false;

            GetComponentInParent<Gatherinput>().OnDisable();
            Debug.Log("Player Dead");

            if (GameOverscreen != null)
            {
                GameOverscreen.Setup(0); 
            }
        }

        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);

        if (health > 0f)
        {
            canTakeDamage = true;
        }
    }
}
