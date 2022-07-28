using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateExample
{
    [System.Serializable]
    public class StateChanger : MonoBehaviour
    {
        /// <summary>
        /// Why we use enum here?
        /// Because we want to make our code simplier. We didn't use enum in the State Machine Pattern.
        /// We just used for make assignment easier.
        /// </summary>
        public enum States {Idle,RotateMove,NoRotateMove}

        [Header("Player")]
        [SerializeField] PlayerMovement player;
        PlayerStateManager playerState;

        [Header("UI")]
        [SerializeField] Button idleStateButton;
        [SerializeField] Button rotateMoveButton;
        [SerializeField] Button noRotateMoveButton;

        private void Start()
        {
            playerState = player.PlayerStateManager;
        }
       
        /// <summary>
        /// We are changing the state with the buttons
        /// </summary>
        /// <param name="states"> Thats why we use the enum :) </param>
        public void ChangeState(int stateValue) 
        {
            switch ((States)stateValue) 
            {
                case States.Idle:
                    playerState.ChangeState(playerState.IdleState);
                    break;
                case States.RotateMove:
                    playerState.ChangeState(playerState.RotateState);
                    break;
                case States.NoRotateMove:
                    playerState.ChangeState(playerState.NoRotateState);
                    break;
            }
        }
        /// <summary>
        /// We want to make selected state's button disabled
        /// </summary>
        public void MakeSelectedButton(Button button) 
        {
            idleStateButton.interactable = true;
            rotateMoveButton.interactable = true;
            noRotateMoveButton.interactable = true;

            button.interactable = false;

        }
    }
}
