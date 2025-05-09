using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine_S : MonoBehaviour
{
    private LineRenderer line;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.Find("Player");
        Vector3 end = Input.mousePosition;
        end.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(end);

        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, worldMousePos);
    }
}
