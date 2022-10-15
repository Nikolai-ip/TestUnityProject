using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlatformerMove : MonoBehaviour, IMoveRegime
{
    [SerializeField] private float _xSpeed;
    private float y = 0;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpSpeed;
    private bool _cubOnGround;
    [SerializeField] private float _gravity;

    public float MoveX()
    {
        return Input.GetAxis("Horizontal") * _xSpeed * Time.deltaTime;
    }

    public float MoveY()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }
        else if (_cubOnGround)
        {
            return _gravity;
        }
        return y;
    }
    private IEnumerator Jump()
    {
        float time = 0;
        _cubOnGround = false;
        while (!_cubOnGround)
        {
            y = JumpFunc(time) * _jumpHeight;
            time += Time.deltaTime * _jumpSpeed;
            yield return null;
        }
        yield break;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _cubOnGround = true;
    }

    private float JumpFunc(float x)
    {
        return -1 * math.pow((x - 2), 2) + 4; // функция для прыжка y = -(x-2)^2+4
    }
}