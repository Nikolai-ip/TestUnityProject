using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMove : MonoBehaviour, IMoveRegime
{
    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;
    public float MoveX()
    {
        return Input.GetAxis("Horizontal") * _xSpeed * Time.deltaTime;
    }

    public float MoveY()
    {
        return Input.GetAxis("Vertical") * _ySpeed * Time.deltaTime;
    }
}
