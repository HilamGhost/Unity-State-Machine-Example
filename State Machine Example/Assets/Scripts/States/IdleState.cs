using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateExample
{
    public class IdleState : IState
    {
        PlayerMovement player;
        public IdleState(PlayerMovement _player)
        {
            player = _player;
        }
        public void OnStateStart()
        {
            player.ResetPlayersVelocity();
            player.ResetPlayersRotation();
            player.ChangeColor(Color.green);
        }
        public void OnStateUpdate()
        {
            player.RotatePlayer();
        }
        public void OnStateExit()
        {

        }
    }
}
