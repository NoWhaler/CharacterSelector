using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameView : MonoBehaviour
    {
        [Header("Containers")]
        [SerializeField] private RectTransform _characterSpawnContainer;

        [Header("Buttons")]
        [SerializeField] private Button _backButton;

        [Header("Canvas")]
        [SerializeField] private Canvas _canvas;

        public event Action OnBackClicked;

        public Transform CharacterSpawnContainer => _characterSpawnContainer;

        public void Initialize()
        {
            _canvas.worldCamera = Camera.main;

            _backButton.onClick.AddListener(HandleBackButtonClick);
        }

        private void HandleBackButtonClick()
        {
            OnBackClicked?.Invoke();
        }

        public void Dispose()
        {
            _backButton.onClick.RemoveListener(HandleBackButtonClick);
        }
    }
}