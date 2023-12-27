using System;
using UnityEngine;
using UnityEngine.Events;

namespace Singnals
{
    public class CoreGameSingals : MonoBehaviour
    {
        #region Singletion

        public static CoreGameSingals Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        #endregion

        public UnityAction<byte> onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onReset = delegate { };
        
        //
        public Func<byte> onGetLevelValue = delegate { return 0; };
    }
}