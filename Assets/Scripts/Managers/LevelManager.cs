using System;
using Commands.Level;
using Data.UnityObjects;
using Data.ValueObjects;
using Singnals;
using UnityEngine;
using UnityEngine.Rendering;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variable

        #region Serialized Variables

        [SerializeField] private Transform levelHolder;
        [SerializeField] private byte totalLevelCount;

        #endregion

        #region Private Variables

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyCommand _levelDestroyCommand;

        private byte _currentLevel;
        private LevelData _levelData;

        #endregion

        #endregion


        private void Awake()
        {
            _levelData = GetLevelData();
            _currentLevel = GetActiveLevel();

            Init();
        }

        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
            _levelDestroyCommand = new OnLevelDestroyCommand(levelHolder);
        }

        private LevelData GetLevelData()
        {
            return Resources.Load<CD_Level>("Data/CD_Level").Levels[_currentLevel];
        }

        private byte GetActiveLevel()
        {
            return _currentLevel;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSingals.Instance.onLevelInitialize += _levelLoaderCommand.Execute;
            CoreGameSingals.Instance.onClearActiveLevel += _levelDestroyCommand.Execute;
            CoreGameSingals.Instance.onGetLevelValue += OnGetLevelValue;
            CoreGameSingals.Instance.onNextLevel += OnNextLevel;
            CoreGameSingals.Instance.onRestartLevel += OnRestartLevel;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSingals.Instance.onLevelInitialize -= _levelLoaderCommand.Execute;
            CoreGameSingals.Instance.onClearActiveLevel -= _levelDestroyCommand.Execute;
            CoreGameSingals.Instance.onGetLevelValue -= OnGetLevelValue;
            CoreGameSingals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSingals.Instance.onRestartLevel -= OnRestartLevel;
        }

        public byte OnGetLevelValue()
        {
            return _currentLevel;
        }

        private void Start()
        {
            CoreGameSingals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }

        private void OnNextLevel()
        {
            _currentLevel++;
            CoreGameSingals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSingals.Instance.onRestartLevel?.Invoke();
            CoreGameSingals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }


        private void OnRestartLevel()
        {
            CoreGameSingals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSingals.Instance.onRestartLevel?.Invoke();
            CoreGameSingals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }
    }
}