using Unity.VisualScripting;
using UnityEngine;

public class Stats_S : MonoBehaviour
{
    private float health = 0.0f;
    private bool isAlive = false;
    [SerializeField] private int Rank = 1;
    [SerializeField] public float Speed = 5f;
    [SerializeField] private float Damage = 1f;

    private void Start()
    {
        health = 20 * Rank;
        isAlive = true;
    }
    
    private void Update()
    {
        if(health <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        health -= other.GetComponent<Stats_S>().Damage;
    }
}
