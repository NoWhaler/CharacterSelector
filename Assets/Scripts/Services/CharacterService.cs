using Interfaces;
using Models;
using UnityEngine;

namespace Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public CharacterModel SelectRandomCharacter()
        {
            int characterCount = _characterRepository.GetCharacterCount();
            
            int randomIndex = Random.Range(0, characterCount);
            CharacterModel selectedCharacter = _characterRepository.GetCharacterByIndex(randomIndex);

            return selectedCharacter;
        }

        public GameObject LoadCharacterPrefab(CharacterModel characterModel)
        {
            GameObject prefab = Resources.Load<GameObject>(characterModel.PrefabPath);
            return prefab;
        }
    }
}