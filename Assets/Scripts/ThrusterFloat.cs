using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterFloat : MonoBehaviour
{
    public float amplitude = 0.1f; // •‚‚«‚Ì•
    public float speed = 1f;      // •‚‚«‚Ì‘¬‚³
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localPosition = startPos + new Vector3(0, offset, 0);
    }
}
