using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateExample
{
    public class NoRotateState : IState
    {
        PlayerMovement player;
        public NoRotateState(PlayerMovement _player)
        {
            player = _player;
        }
        public void OnStateStart()
        {            
            player.ChangeRigidbodyConstraints(true);
            player.ResetPlayersRotation();
            player.ChangeColor(Color.red);
        }
        public void OnStateUpdate()
        {
            player.Move();
        }
        public void OnStateExit()
        {
            player.ChangeRigidbodyConstraints(false);
        }
    }
}
