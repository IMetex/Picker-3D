using UnityEngine;

namespace Commands.Level
{
    public class OnLevelDestroyCommand
    {
        private Transform _levelHolder;
        public OnLevelDestroyCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        
        public void Execute()
        {
            if (_levelHolder.transform.childCount <= 0)
                return;
            
            Object.Destroy(_levelHolder.transform.GetChild(0).gameObject);
        }
    }
}