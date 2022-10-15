using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private Color _color2;
    private SpriteRenderer _sr;
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    public void ColorChange(bool cond)
    {
        _sr.color = cond ? _color : _color2;
    }
}
