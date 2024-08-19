using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader _playerInputReader { get; set; }
    public PlayerMove MoveCompo { get; set; }

    private void Awake()
    {
        MoveCompo = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        _playerInputReader.JumpKeyEvent += MoveCompo.Jump;
        _playerInputReader.MovementEvent += MoveCompo.SetMoveMent;
    }

    private void Update()
    {
        LookForKeyBoard();    
    }

    private void LookForKeyBoard()
    {
        if (_playerInputReader.Movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -150, 0);
        }
        else if (_playerInputReader.Movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_playerInputReader.Movement.x == 0 && transform.rotation == Quaternion.Euler(0,-150,0))
        {
            transform.rotation = Quaternion.Euler(0, -150, 0);
        }
    }
}
