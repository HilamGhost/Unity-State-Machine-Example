using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateExample
{
    /// <summary>
    /// We use IState interface for getting methods for easier.
    /// </summary>
    public interface IState
    {
        public void OnStateStart();
        public void OnStateUpdate();
        public void OnStateExit();

    }
}
