using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Shooting_S : MonoBehaviour
{
    private Vector2 start;
    private Vector2 end;
    private Vector2 direction;
    private float power = 0.0f;
    private float speed = 1f;
    private bool increasing = false;
    private bool charging = false;
    private Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject)
        {
            start = gameObject.transform.position;
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (end - start).normalized;
            if (Input.GetMouseButtonDown(0)) { charging = true; }
            if (charging)
            {
                if (increasing)
                {
                    power += speed * Time.deltaTime;
                    if (power >= 1.0f)
                    {
                        power = 1.0f;
                        increasing = false;
                    }
                }
            }
            else
            {
                power -= speed * Time.deltaTime;
                if (power <= 0.0f)
                {
                    power = 0.0f;
                    increasing = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = direction * (power * gameObject.GetComponent<Stats_S>().Speed);
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            if(gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude < 0.000001f)
            {
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
