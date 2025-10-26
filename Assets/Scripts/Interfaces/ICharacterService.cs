using Models;
using UnityEngine;

namespace Interfaces
{
    public interface ICharacterService
    {
        CharacterModel SelectRandomCharacter();
        GameObject LoadCharacterPrefab(CharacterModel characterModel);
    }
}