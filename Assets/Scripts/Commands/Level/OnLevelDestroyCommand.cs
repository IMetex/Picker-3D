using UnityEngine;

namespace Commands.Level
{
    public class OnLevelDestroyCommand
    {
        private Transform _levelHolder;
        internal OnLevelDestroyCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        
        internal void Execute()
        {
            if (_levelHolder.transform.childCount <= 0)
                return;
            
            Object.Destroy(_levelHolder.transform.GetChild(0).gameObject);
        }
    }
}