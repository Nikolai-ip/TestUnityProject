using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour
{
    public bool Value { get; private set; }
    [SerializeField] private Animator _animator;
    private static readonly int _nameAnim = Animator.StringToHash("TogglerValue");
    public event Action<bool> onRegimeMoveChange;
    public event Action<bool> onColorChange;
    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        Value = true;
        _animator.SetBool(_nameAnim, Value);
        onRegimeMoveChange = FindObjectOfType<MoveController>().ChangeRegime;
        foreach (var colorChanger in FindObjectsOfType<ChangeColor>())
        {
            onColorChange += colorChanger.ColorChange;
        }

    }
    public void Toggle()
    {
        Value = !Value;
        onRegimeMoveChange(Value);
        onColorChange(Value);
        _animator.SetBool(_nameAnim, Value);
    }
}
