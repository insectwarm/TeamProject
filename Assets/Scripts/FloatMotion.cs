using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMotion : MonoBehaviour
{
    public float amplitude = 10f; // 上下の揺れ幅（10くらいで様子見）
    public float speed = 1.0f;    // 揺れる速さ
    private Vector2 startPos;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        rectTransform.anchoredPosition = startPos + new Vector2(0, yOffset);
    }
}