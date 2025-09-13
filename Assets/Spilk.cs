using UnityEngine;


public class Spilk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage = 2f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStus"))
        {
        Debug.Log("Player Hit");
        collision.GetComponent<PlayerStus>().TakeDamage(damage);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
