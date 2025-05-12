using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class Shooting_S : MonoBehaviour
{
    private Vector2 start;
    private Vector2 end;
    private Vector2 direction;
    public float power = 0.0f;
    private float speed =  0.5f;
    private bool increasing = false;
    private bool charging = false;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject)
        {
            start = gameObject.transform.position;
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (end - start).normalized;
            if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<Stats_S>().active) { charging = true; }
            if (charging)
            {
                if (increasing)
                {
                    power += speed * Time.deltaTime;
                    if (power >= 1f)
                    {
                        power = 1f;
                        increasing = false;
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
            }
            if (Input.GetMouseButtonUp(0))
            {
                charging = false;
                gameObject.GetComponent<Stats_S>().active = false;
                if(!gameObject.GetComponent<Stats_S>().active)
                {
                    gameObject.GetComponent<Rigidbody2D>().linearVelocity = direction * (power * gameObject.GetComponent<Stats_S>().Speed);
                    power = 0f;
                    return;
                }   
            }
        }   
    }
}
