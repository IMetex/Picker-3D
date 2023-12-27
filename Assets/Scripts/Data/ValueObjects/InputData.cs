using System;
using UnityEngine;

namespace Data.ValueObjects
{
    [Serializable]
    public struct InputData
    {
        public float HorizontalInput;
        public Vector2 ClampValue;
        public float ClampSpeed;
        
    }
}