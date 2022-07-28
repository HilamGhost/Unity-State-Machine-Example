using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateExample
{
    public class PlayerStateManager
    {
        PlayerMovement player;
       
        IState currentState;
        
        IdleState idleState;
        RotateState rotateState;
        NoRotateState noRotateState;

        #region Properties
        public IdleState IdleState => idleState;
        public RotateState RotateState => rotateState;
        public NoRotateState NoRotateState => noRotateState;
        #endregion
        public PlayerStateManager(PlayerMovement _player) 
        {
            player = _player;

            idleState = new IdleState(player);
            rotateState = new RotateState(player);
            noRotateState = new NoRotateState(player);

            currentState = rotateState;
            currentState.OnStateStart();
        }

        /// <summary>
        /// We are running the selected State's Update.
        /// </summary>
        public void OnStateUpdate() 
        {
            currentState.OnStateUpdate();
        }

        /// <summary>
        /// Changes the player's state
        /// </summary>
        /// <param name="state">You must use this format: player.PlayerState.IState</param>
        public void ChangeState(IState state)
        {
            if (state != currentState)
            {
                currentState.OnStateExit();
                currentState = state;
                currentState.OnStateStart();
            }

        }

        /// <summary>
        /// Is the wanted state equal player's state
        /// </summary>
        /// <param name="state">You must use this format: player.PlayerState.IState</param>
        public bool IsPlayerStateEqual(IState state)
        {
            if (state == currentState) return true;
            else return false;
        }
    }
}

