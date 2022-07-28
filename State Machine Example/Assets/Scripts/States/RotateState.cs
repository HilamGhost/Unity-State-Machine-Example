using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateExample
{
    public class RotateState : IState
    {
        PlayerMovement player;
        public RotateState(PlayerMovement _player) 
        {
            player = _player;
        }
        public void OnStateStart()
        {
            player.ChangeColor(Color.blue);
        }
        public void OnStateUpdate()
        {
            player.Move();
        }
        public void OnStateExit()
        {
            
        }
    }
}
