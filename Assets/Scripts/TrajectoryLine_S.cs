using System.Data;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine_S : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField]
    private float lineLength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        lineLength = 2;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject != null)
        {
            line.enabled = true;
            Vector3 end = Input.mousePosition;
            end.z = Mathf.Abs(Camera.main.transform.position.z);
            end = Camera.main.ScreenToWorldPoint(end);
            Vector3 direction = (end - gameObject.transform.position).normalized;
            Vector3 endpoint = gameObject.transform.position + direction * lineLength;

            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, endpoint);
        }
        else
        {
            line.enabled = false;
        }
    }
}