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
    public class CharacterSelectorPresenter: IInitializable, IDisposable
    {
        private ICharacterService _characterService;
        private ISceneNavigationService _sceneNavigationService;
        private ISessionService _sessionService;
        private IViewFactory _viewFactory;
        
        private DiContainer _diContainer;

        private CharacterSelectorView _characterSelectorView;
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
            GameObject viewPrefab = _viewFactory.GetViewPrefab(ViewType.CharacterSelectorView);
            _characterSelectorView = _diContainer.InstantiatePrefabForComponent<CharacterSelectorView>(viewPrefab);
            _characterSelectorView.Initialize();

            _characterSelectorView.OnGenerateClicked += HandleGenerateCharacter;
            _characterSelectorView.OnPlayClicked += HandlePlayButton;
            
            SpawnSelectedCharacter();
        }

        public void Dispose()
        {
            ClearCharacter();

            _characterSelectorView.OnGenerateClicked -= HandleGenerateCharacter;
            _characterSelectorView.OnPlayClicked -= HandlePlayButton;
            _characterSelectorView.Dispose();
        }

        private void HandleGenerateCharacter()
        {
            ClearCharacter();

            CharacterModel selectedCharacter = _characterService.SelectRandomCharacter();
            _sessionService.SetSelectedCharacter(selectedCharacter);

            GameObject characterPrefab = _characterService.LoadCharacterPrefab(selectedCharacter);
            _currentCharacterInstance =
                _diContainer.InstantiatePrefab(characterPrefab, _characterSelectorView.CharacterSpawnContainer);
        }

        private void SpawnSelectedCharacter()
        {
            if (_sessionService.SelectedCharacter == null) return;

            CharacterModel selectedCharacter = _sessionService.SelectedCharacter;
            GameObject characterPrefab = _characterService.LoadCharacterPrefab(selectedCharacter);
            _currentCharacterInstance =
                _diContainer.InstantiatePrefab(characterPrefab, _characterSelectorView.CharacterSpawnContainer);
        }

        private void ClearCharacter()
        {
            if (_currentCharacterInstance != null)
            {
                Object.Destroy(_currentCharacterInstance);
                _currentCharacterInstance = null;
            }
        }

        private void HandlePlayButton()
        {
            _sceneNavigationService.LoadGameScene(SceneType.Game);
        }
    }
}