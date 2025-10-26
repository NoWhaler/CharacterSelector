using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CharacterSelectorView : MonoBehaviour
    {
        [Header("Containers")]
        [SerializeField] private Transform _characterSpawnContainer;

        [Header("Buttons")]
        [SerializeField] private Button _generateButton;
        [SerializeField] private Button _playButton;

        [Header("Canvas")]
        [SerializeField] private Canvas _canvas;

        public event Action OnGenerateClicked;
        public event Action OnPlayClicked;

        public Transform CharacterSpawnContainer => _characterSpawnContainer;

        public void Initialize()
        {
            _canvas.worldCamera = Camera.main;

            _generateButton.onClick.AddListener(HandleGenerateButtonClick);
            _playButton.onClick.AddListener(HandlePlayButtonClick);
        }

        private void HandleGenerateButtonClick()
        {
            OnGenerateClicked?.Invoke();
        }

        private void HandlePlayButtonClick()
        {
            OnPlayClicked?.Invoke();
        }

        public void Dispose()
        {
            _generateButton.onClick.RemoveListener(HandleGenerateButtonClick);
            _playButton.onClick.RemoveListener(HandlePlayButtonClick);
        }
    }
}