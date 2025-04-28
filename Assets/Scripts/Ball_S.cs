using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class Ball_S : MonoBehaviour
{
    Vector3 velocity; 
    float rank,hp;
    Camera cam;

    [SerializeField]
    float force = 10f;

    Vector3 startPoint;
    Vector3 endPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity.x = 0;
        velocity.y = 0;
        rank = 1;
        hp = 100;
        cam = Camera.main;
        GameObject gameObject = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(mousePosition);
            startPoint.z += 10f; 
            Debug.Log("Start: " + startPoint);
        }

        if(Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(mousePosition);
            endPoint.z = 0f;
            Debug.Log("End: " + endPoint);
            velocity = (startPoint - endPoint) * force;
        }
        gameObject.transform.position += velocity * Time.deltaTime;
    }
}
