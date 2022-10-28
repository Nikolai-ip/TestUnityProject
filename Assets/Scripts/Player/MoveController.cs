using System.Collections.Generic;
using UnityEngine;
#region
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlatformerMove))]
[RequireComponent(typeof(FreeMove))]
#endregion
public class MoveController : MonoBehaviour
{

    private Dictionary<RegimeType,IMoveRegime> _moveRegimesMap = new Dictionary<RegimeType, IMoveRegime>();
    public RegimeType CurrentMoveRegime { private get; set; }
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveRegimesMap.Add(RegimeType.platformer, GetComponent<PlatformerMove>());
        _moveRegimesMap.Add(RegimeType.freeMove, GetComponent<FreeMove>()); 
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveRegimesMap[CurrentMoveRegime].MoveX(), _moveRegimesMap[CurrentMoveRegime].MoveY());
    }
    public void ChangeRegime(bool cond)
    {
        CurrentMoveRegime = cond ? RegimeType.platformer : RegimeType.freeMove;
    }
}
