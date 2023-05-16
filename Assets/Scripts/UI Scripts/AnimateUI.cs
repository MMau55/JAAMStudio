using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateUI : MonoBehaviour
{
    public GameObject imagen;
    public float amplitude = 4;
    public float speed = 1.5f;
    private float startY;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = imagen.GetComponent<RectTransform>();
        startY = rectTransform.anchoredPosition.y;
        //Debug.Log("Entramos siempre.... o no?");
    }

    private void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
    }
}
