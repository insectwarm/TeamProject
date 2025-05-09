using Unity.VisualScripting;
using UnityEngine;

public class Shooting_S : MonoBehaviour
{
    private Vector2 start;
    private Vector2 end;
    private Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.Find("Player");
        if (gameObject)
        {
            start = gameObject.transform.position;
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (end - start).normalized;
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.GetComponentInParent<Rigidbody2D>().linearVelocity =direction * gameObject.GetComponentInParent<Stats_S>().Speed;
            }
        }
    }
}
