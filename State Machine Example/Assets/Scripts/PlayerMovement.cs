using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateExample
{
    [RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody _playerRB;
        PlayerStateManager _playerStateManager;
        [Header("Movement")]
        [SerializeField] float moveSpeed;

        #region Properties
        /// <summary>
        /// We use Properties because we have to access from other scripts
        /// </summary>
        public PlayerStateManager PlayerStateManager => _playerStateManager;
        #endregion
        // Start is called before the first frame update
        void Awake()
        {
            _playerStateManager = new PlayerStateManager(this);
            _playerRB = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            _playerStateManager.OnStateUpdate();
        }

        /// <summary>
        /// I usually get Input from other method. However for this project, our goal is learning State Machine Pattern so tihs part is not nessesary. 
        /// </summary>
        public void Move()
        {
            float _verticalMove = Input.GetAxis("Vertical")*moveSpeed;
            float _horizontalMove = Input.GetAxis("Horizontal")*moveSpeed;

            Vector3 _moveDirection = Vector3.forward * _verticalMove + Vector3.right * _horizontalMove +Vector3.up*_playerRB.velocity.y;
            _playerRB.velocity = _moveDirection;
        }

        /// <summary>
        /// I used this method for signal the change stating
        /// </summary>
        /// <param name="_wantedColor"> What we want for color? </param>
        public void ChangeColor(Color _wantedColor) 
        {
            GetComponent<Renderer>().material.color = _wantedColor;
        }

        /// <summary>
        /// In this method we are changing the rigidbody's constraints
        /// </summary>
        /// <param name="_isFreezed">If value is true rigidbody is freezed</param>
        public void ChangeRigidbodyConstraints(bool _isFreezed) 
        {
            if (_isFreezed) _playerRB.freezeRotation = true;
            else _playerRB.freezeRotation = false;
        }
        /// <summary>
        /// In this method we are rotating player.
        /// </summary>
        public void RotatePlayer() 
        {
            transform.Rotate(0,45*Time.deltaTime,0);
        }
        /// <summary>
        /// In this code, we are resetting our player's rotation into the zero
        /// </summary>
        public void ResetPlayersRotation() 
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        /// <summary>
        /// In this code, we are resetting our player's velocity into the zero
        /// </summary>
        public void ResetPlayersVelocity()
        {
            _playerRB.velocity = Vector3.zero;
        }
    }
}
