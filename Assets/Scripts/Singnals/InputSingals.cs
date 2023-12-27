using System;
using Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Singnals
{
    public class InputSingals : MonoBehaviour
    {
        #region Singleton

        public static InputSingals Instance;

        private void Awake()
        {
            if (Instance != null && Instance !=this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        #endregion
        
        public UnityAction onFirstTouchTaken = delegate { };
        public UnityAction onInputTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate { };


    }
}