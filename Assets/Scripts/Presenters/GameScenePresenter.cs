using System;
using Enums;
using Interfaces;
using Models;
using UnityEngine;
using Views;
using Zenject;
using Object = UnityEngine.Object;

namespace Presenters
{
    public class GameScenePresenter: IInitializable, IDisposable
    {
        private ICharacterService _characterService;
        private ISceneNavigationService _sceneNavigationService;
        private ISessionService _sessionService;
        private IViewFactory _viewFactory;

        private DiContainer _diContainer;

        private GameView _gameView;
        private GameObject _currentCharacterInstance;

        [Inject]
        private void Inject(
            ICharacterService characterService,
            ISceneNavigationService sceneNavigationService,
            ISessionService sessionService,
            IViewFactory viewFactory,
            DiContainer diContainer)
        {
            _characterService = characterService;
            _sceneNavigationService = sceneNavigationService;
            _sessionService = sessionService;
            _viewFactory = viewFactory;
            _diContainer = diContainer;
        }
        
        public void Initialize()
        {
            GameObject viewPrefab = _viewFactory.GetViewPrefab(ViewType.GameView);
            _gameView = _diContainer.InstantiatePrefabForComponent<GameView>(viewPrefab);
            _gameView.Initialize();

            _gameView.OnBackClicked += HandleBackButton;

            SpawnSelectedCharacter();
        }

        public void Dispose()
        {
            ClearCharacter();

            _gameView.OnBackClicked -= HandleBackButton;
            _gameView.Dispose();
        }

        private void SpawnSelectedCharacter()
        {
            CharacterModel selectedCharacter = _sessionService.SelectedCharacter;
            GameObject characterPrefab = _characterService.LoadCharacterPrefab(selectedCharacter);
            _currentCharacterInstance = _diContainer.InstantiatePrefab(characterPrefab, _gameView.CharacterSpawnContainer);
        }

        private void ClearCharacter()
        {
            if (_currentCharacterInstance != null)
            {
                Object.Destroy(_currentCharacterInstance);
                _currentCharacterInstance = null;
            }
        }

        private void HandleBackButton()
        {
            _sceneNavigationService.LoadGameScene(SceneType.CharacterSelector);
        }
    }
}