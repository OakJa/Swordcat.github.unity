using UnityEngine;
using System.Collections; // สำหรับ IEnumerator และ WaitForSeconds

public class PlayerStus : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool canTakeDamage = true;

    private Animator animator;

     private bool isDead = false;

    void Start()
    {
        health = maxHealth;
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        // ไม่มีอะไรจะทำที่นี่ในตอนนี้
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
            return;

        // ลด HP ตามที่เสียหาย
        health -= damage;

        if (health <= 0f)
        {
            isDead = true;
            animator.SetBool("dead", true);
            GetComponent<PolygonCollider2D>().enabled = false;

            // หากมีคลาส GatherInput ให้เรียกฟังก์ชันที่คุณสร้างขึ้นเองแทน OnDisable
            GetComponentInParent<Gatherinput>().OnDisable();
         
            Debug.Log("Player Dead");
        }

        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        // เปิดการรับความเสียหายใหม่ถ้าผู้เล่นยังมี HP มากกว่า 0
        if (health > 0f)
        {
            canTakeDamage = true;
        }
    }
}