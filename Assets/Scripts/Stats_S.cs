using Unity.VisualScripting;
using UnityEngine;

public class Stats_S : MonoBehaviour
{
    private float health = 0.0f;
    [SerializeField] private int Rank = 1;
    [SerializeField] public float Speed = 5f;
    [SerializeField] private float Damage = 5f;

    private void Start()
    {
        health = 20 * Rank;
    }
    
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obsticle"))
        {
            GameObject other = collision.gameObject;
            health -= other.GetComponent<Stats_S>().Damage;
        }
        else { return ; }
    }
}
