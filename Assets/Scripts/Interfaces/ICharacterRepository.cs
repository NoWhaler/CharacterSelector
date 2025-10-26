using Models;

namespace Interfaces
{
    public interface ICharacterRepository
    {
        int GetCharacterCount();
        CharacterModel GetCharacterByIndex(int index);
    }
}