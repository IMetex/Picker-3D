using System;
using Data.UnityObjects;
using Data.ValueObjects;
using Singnals;
using Unity.Mathematics;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self  Variables

        #region Private  Variables

        private InputData _data;
        private bool isAvailableForTouch, isFirstTimeTouchTaken, isTouching;

        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;

        #endregion

        #endregion

        private void Awake()
        {
            _data = GetInputData();
        }

        private InputData GetInputData()
        {
            return Resources.Load<CD_Input>("Data/CD_Input").Data;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSingals.Instance.onReset += OnReset;
            
        }

        private void OnReset()
        {
            isAvailableForTouch = false;
           // isFirstTimeTouchTaken = false;
            isTouching = false;
        }
    }
}