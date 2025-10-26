using System.Collections.Generic;
using Interfaces;
using Models;
using UnityEngine;

namespace Services
{
    public class CharacterRepository : ICharacterRepository
    {
        private const string PREFABS_FOLDER = "Prefabs/References";
        private const string PREFAB_SUB_NAME = "CharaRef";
        
        private List<CharacterModel> _availableCharacters;

        public CharacterRepository()
        {
            LoadAvailableCharacters();
        }

        private void LoadAvailableCharacters()
        {
            _availableCharacters = new List<CharacterModel>();

            GameObject[] prefabs = Resources.LoadAll<GameObject>(PREFABS_FOLDER);

            foreach (GameObject prefab in prefabs)
            {
                if (prefab.name.StartsWith(PREFAB_SUB_NAME))
                {
                    string prefabPath = $"{PREFABS_FOLDER}/{prefab.name}";
                    CharacterModel characterModel = new CharacterModel(prefabPath);
                    _availableCharacters.Add(characterModel);
                }
            }
        }

        public int GetCharacterCount()
        {
            return _availableCharacters.Count;
        }

        public CharacterModel GetCharacterByIndex(int index)
        {
            return _availableCharacters[index];
        }
    }
}